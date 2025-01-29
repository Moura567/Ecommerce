namespace WebApplication1.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal totalprice {  get; set; }
        public string? image { get; set; }

        public string categoryName {  get; set; }
    }
}
