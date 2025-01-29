using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OrderRepo(Context context) : IOrderRepo
    {
        private readonly Context context;

        public void AddOrder(OrderItem orderItem)
        {
            context.OrderItems.Add(orderItem);
        }

        public void ClearOrderItem(int orderid)
        {
            var orderItems = context.OrderItems.FirstOrDefault(x=>x.OrderId == orderid);
            context.OrderItems.Remove(orderItems);
        }
        public void CancelOrder(int id)
        {
            var order=context.orders.Find(id);
            ClearOrderItem(order.Id);
            context.Remove(order);
        }

        public Order GetOrder(int id)
        {
            return context.orders.Find(id);
        }
        public IEnumerable<Order> GetOrders()
        {
            return context.orders.ToList();
        }
        public void MakeOrder(Order order)
        {
            context.orders.Add(order);
        }

        public IEnumerable<Order> OrderList(string userid)
        {
            return context.orders.Where(x=>x.UserId==userid).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public Order GetOrder(string userid)
        {
            return context.orders
                              .Where(x => x.UserId == userid)
                              .OrderByDescending(x => x.CreateDate)
                              .FirstOrDefault();
        }
        public void update(Order order) { context.orders.Update(order); }

    }
}
