using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }

        [Display(Name ="Category")]
        public int categoryId { get; set; }
        public string? image { get; set; }
        [NotMapped]
        public IFormFile imageuploder { get; set; }
        public virtual Category ?Category { get; set; }

        public IEnumerable<Order> Order { get; set; }


    }
}
