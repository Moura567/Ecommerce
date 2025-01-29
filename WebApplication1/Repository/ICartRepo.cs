using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ICartRepo
    {
        public IEnumerable<CartItem> GetCartItems(int id);

        public int GetOrCreateCartId(string userid);
        public CartItem GetCartItem(int cartId, int productId);
        public void UpdateCartItem(CartItem cartItem);
        public void AddToCart(CartItem cartItem);
        public void RemoveFromCart(CartItem cartItem);
        public Cart GetByID(int id);
        public int GetTotalItemsInCart(int cartId);

        public void ClearCart(int cartid);
        public void save();
    }
}
