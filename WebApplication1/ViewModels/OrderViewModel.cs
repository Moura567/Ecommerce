using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        public int amount { get; set; }
        public int productId { get; set; }
        public int categoryId { get; set; }

        public string productName { get; set; }

        public int cartId { get; set; }
        public string categoryName {  get; set; }

        public decimal totalprice { get; set; }
        public string location { get; set; }
        public string State { get; set; }
        public string image { get; set; }

        List<OrderItem> items { get; set; }

        public string userID { get; set; }
        public string userName { get; set; }

        public DateTime orderDate { get; set; }
    }
}
