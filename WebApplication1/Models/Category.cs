namespace WebApplication1.Models
{
    public class Category
    {
        public Category()
        {
            products = new HashSet<product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ICollection<product> ?products {  get; set; }
    }
}
