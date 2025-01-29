using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IOrderRepo
    {
        public void MakeOrder(Order order);
        public void CancelOrder(int id);
        public void AddOrder(OrderItem orderItem);
        public IEnumerable<Order> OrderList(string userid);
        public void Save();
        public Order GetOrder(string userid);
        public IEnumerable< Order> GetOrders();

        public Order GetOrder(int id);
        public void update(Order order);
    }
}
