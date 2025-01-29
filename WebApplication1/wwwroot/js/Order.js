document.addEventListener('DOMContentLoaded', function () {
    const orderListContainer = document.getElementById('orderListContainer');

    // Event delegation for order state change & delete buttons
    orderListContainer.addEventListener('change', function (event) {
        if (event.target.classList.contains('order-state-dropdown')) {
            updateOrderState(event.target);
        }
    });

    orderListContainer.addEventListener('click', function (event) {
        if (event.target.classList.contains('delete-order')) {
            deleteOrder(event.target);
        }
    });

    document.getElementById('selectAll').addEventListener('change', toggleAllCheckboxes);
    document.getElementById('deleteSelectedOrders').addEventListener('click', deleteSelectedOrders);
    document.getElementById('searchInput').addEventListener('input', searchOrders);
});

function updateOrderState(dropdown) {
    const orderId = dropdown.dataset.orderId;
    const newState = dropdown.value;

    fetch('/Order/UpdateOrderState', {
        method: 'POST',
        headers: getHeaders(),
        body: JSON.stringify({ orderId, newState })
    })
        .then(response => response.json())
        .then(data => {
            if (!data.success) alert('Failed: ' + data.message);
        })
        .catch(() => alert('Error updating order state.'));
}

function deleteOrder(button) {
    const orderId = button.dataset.orderId;
    if (!confirm('Are you sure you want to delete this order?')) return;

    fetch(`/Order/DeleteOrder?orderId=${orderId}`, {
        method: 'DELETE',
        headers: getHeaders()
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) button.closest('tr').remove();
            else alert('Failed: ' + data.message);
        })
        .catch(() => alert('Error deleting order.'));
}

function toggleAllCheckboxes() {
    document.querySelectorAll('.order-checkbox').forEach(cb => cb.checked = this.checked);
}

function deleteSelectedOrders() {
    const selectedOrders = [...document.querySelectorAll('.order-checkbox:checked')]
        .map(cb => parseInt(cb.dataset.orderId));

    if (selectedOrders.length === 0 || !confirm('Delete selected orders?')) return;

    fetch('/Order/DeleteOrders', {
        method: 'POST',
        headers: getHeaders(),
        body: JSON.stringify(selectedOrders)
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) selectedOrders.forEach(id =>
                document.querySelector(`.order-checkbox[data-order-id="${id}"]`).closest('tr').remove()
            );
            else alert('Failed: ' + data.message);
        })
        .catch(() => alert('Error deleting orders.'));
}

function searchOrders() {
    const query = this.value.trim();
    if (query.length < 2 && query !== "") return;

    fetch(`/Order/SearchOrders?searchTerm=${encodeURIComponent(query)}`)
        .then(response => response.text())
        .then(data => document.getElementById('orderListContainer').innerHTML = data)
        .catch(() => alert('Error loading search results.'));
}

function getHeaders() {
    return {
        'Content-Type': 'application/json',
        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
    };
}

