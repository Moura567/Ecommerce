namespace WebApplication1.Models
{
    public class UpdateOrderStateRequest
    {
        public int OrderId { get; set; }
        public string NewState { get; set; }
    }
}
