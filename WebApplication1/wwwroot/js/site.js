function submitAddToCartForm(form) {
    const formData = new FormData(form);

    fetch(form.action, {
        method: 'POST',
        headers: {
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        },
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.error) {
                alert(data.error);
            } else {
                const cartCountElement = document.getElementById("cartCount");
                cartCountElement.textContent = data.totalItems;

                const productAmountElement = document.getElementById("amount_" + data.productId);
                if (productAmountElement) {
                    productAmountElement.textContent = data.updatedAmount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                }
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("There was an issue adding the item to the cart.");
        });

    return false;
}
function submitRemoveFromCartForm(form) {
    const formData = new FormData(form);

    fetch(form.action, {
        method: 'POST',
        headers: {
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        },
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            const cartCountElement = document.getElementById("cartCount");

            if (data.error) {
                alert(data.error);
            } else {
                cartCountElement.textContent = data.totalItems;

                const productAmountElement = document.getElementById("amount_" + data.productId);
                if (productAmountElement) {
                    productAmountElement.textContent = data.updatedAmount ? data.updatedAmount : data.productAmount;
                }

            }
        })
        .catch(error => {
            console.error('Error:', error.message);
            alert(`There was an issue removing the item from the cart: ${error.message}`);
        });

    return false;
}


document.addEventListener("DOMContentLoaded", function () {
    const cartCountElement = document.getElementById("cartCount");

    // Fetch cart count only for authenticated users
    fetch('/Cart/GetCartCount')
        .then(response => {
            if (response.ok) {
                return response.json();
            } else if (response.status === 401) { // Unauthorized
                alert("You must be logged in to view your cart.");
                return null; // Return null to avoid processing
            } else {
                throw new Error("Unexpected error");
            }
        })
        .then(data => {
            if (data && data.error) {
                alert(data.error);
            } else if (data) {
                cartCountElement.textContent = data.totalItems;
            }
        })
        .catch(error => {
            
        });

    // Update total price dynamically when quantity changes
    const quantityInputs = document.querySelectorAll('.quantity');

    quantityInputs.forEach(input => {
        input.addEventListener('input', function () {
            const quantity = parseInt(this.value);
            const price = parseFloat(this.dataset.price);
            const totalPriceElement = document.getElementById(`totalPrice_${this.id.split('_')[1]}`);

            if (quantity > 0) {
                totalPriceElement.textContent = (quantity * price).toFixed(2);
            } else {
                totalPriceElement.textContent = "0.00";
            }
        });
    });
});

function submitCartForm(form, actionType) {
    const formData = new FormData(form);
    const actionUrl = form.action;

    fetch(actionUrl, {
        method: 'POST',
        headers: {
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        },
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.error) {
                alert(data.error);
            } else {
                const cartCountElement = document.getElementById("cartCount");
                cartCountElement.textContent = data.totalItems;

                const productAmountElement = form.closest('tr').querySelector('.product-amount');
                let currentAmount = parseInt(productAmountElement.textContent);
                if (actionType === 'add') {
                    currentAmount -= parseInt(formData.get('quantity'));
                } else if (actionType === 'remove') {
                    currentAmount += parseInt(formData.get('quantity'));
                }
                productAmountElement.textContent = currentAmount;
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("There was an issue processing your request.");
        });

    return false;
}
document.addEventListener("DOMContentLoaded", function () {
    const updateQuantity = (productId, quantityChange) => {
        const quantityElement = document.getElementById(`quantity_${productId}`);
        let currentQuantity = parseInt(quantityElement.textContent.replace(/,/g, ''));

        if (currentQuantity + quantityChange < 1) return; 
        const newQuantity = currentQuantity + quantityChange;

        fetch(`/Cart/UpdateCartItem?productId=${productId}&quantity=${newQuantity}`, {
            method: 'GET',
            headers: {
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.error) {
                    alert(data.error);  
                } else {
                    quantityElement.textContent = newQuantity.toLocaleString();  

                    const totalPriceElement = document.getElementById(`totalPrice_${productId}`);
                    totalPriceElement.textContent = data.updatedTotalPrice.toLocaleString('en-US', { style: 'currency', currency: 'USD' });

                    const cartCountElement = document.getElementById("cartCount");
                    cartCountElement.textContent = data.totalItems;
                }
            })
            .catch(error => {
                console.error('Error:', error);
                alert("There was an issue updating the cart.");
            });
    };

    const increaseButtons = document.querySelectorAll('.btn-increase');
    const decreaseButtons = document.querySelectorAll('.btn-decrease');

    increaseButtons.forEach(button => {
        button.addEventListener('click', () => {
            const productId = button.getAttribute('data-product-id');
            updateQuantity(productId, 1);
        });
    });

    decreaseButtons.forEach(button => {
        button.addEventListener('click', () => {
            const productId = button.getAttribute('data-product-id');
            updateQuantity(productId, -1);
        });
    });
});

const toggleButton = document.getElementById('toggleDarkMode');
const icon = document.getElementById('modeIcon');

// Check if dark mode is enabled from localStorage
if (localStorage.getItem('darkMode') === 'true') {
    document.body.classList.add('dark-mode');
    icon.classList.remove('fa-moon');
    icon.classList.add('fa-sun'); // Set sun icon for dark mode
}

toggleButton.addEventListener('click', function () {
    // Toggle dark mode class
    document.body.classList.toggle('dark-mode');

    // Check if dark mode is active
    const isDarkMode = document.body.classList.contains('dark-mode');

    // Save the current mode in localStorage
    localStorage.setItem('darkMode', isDarkMode);

    // Change icon based on dark mode toggle
    if (isDarkMode) {
        icon.classList.remove('fa-moon');
        icon.classList.add('fa-sun'); // Change moon icon to sun
    } else {
        icon.classList.remove('fa-sun');
        icon.classList.add('fa-moon'); // Change sun icon to moon
    }
});

