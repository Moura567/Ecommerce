using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly Context context;

        public CartRepo(Context context)
        {
            this.context = context;
        }

        public void AddToCart(CartItem cartItem)
        {
            var existingItem = context.CartItems
                                      .FirstOrDefault(x => x.CartId == cartItem.CartId && x.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;  // Update quantity
                context.CartItems.Update(existingItem);
            }
            else
            {
                context.CartItems.Add(cartItem);  // Add new item
            }
        }

        public int GetOrCreateCartId(string userId)
        {
            var cart = context.carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    createdat = DateTime.Now
                };
                context.carts.Add(cart);
                context.SaveChanges(); 
            }

            return cart.Id;
        }

        public IEnumerable<CartItem> GetCartItems(int cartId)
        {
            return context.CartItems
                          .Where(x => x.CartId == cartId)
                          .ToList();
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            context.CartItems.Remove(cartItem);
        }

        // Save changes to the database
        public void save()
        {
            context.SaveChanges();
        }

        // Get Cart by ID
        public Cart GetByID(int id)
        {
            return context.carts.Find(id);
        }

        // Simplified UpdateCartItem
        public void UpdateCartItem(CartItem cartItem)
        {
            // Since AddToCart handles both adding and updating, this method might not be necessary.
            // If you still need it for some reason, here's the simplified version:
            var existingItem = context.CartItems
                                      .FirstOrDefault(ci => ci.CartId == cartItem.CartId && ci.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity = cartItem.Quantity;
                context.CartItems.Update(existingItem);
            }
            else
            {
                context.CartItems.Add(cartItem);
            }
        }

        // Get specific cart item by cartId and productId
        public CartItem GetCartItem(int cartId, int productId)
        {
            return context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        // Get the total number of items in the cart
        public int GetTotalItemsInCart(int cartId)
        {
            return context.CartItems
                .Where(c => c.CartId == cartId)
                .Sum(c => c.Quantity);
        }

            public void ClearCart(int cartid)
        {
            var cartItems = context.CartItems.Where(c => c.CartId == cartid);

            context.CartItems.RemoveRange(cartItems);

        }

    }
    }

