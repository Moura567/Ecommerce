namespace WebApplication1.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId {  get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public int OrderId {  get; set; }
        public List<OrderItem> OrderItems{ get; set; }
    }
}
