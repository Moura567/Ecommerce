
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; 
namespace WebApplication1.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "The Category field is required.")]
        [Display(Name = "Category")]
        public int categoryId { get; set; }

        [Display(Name ="Category")]
        public string categoryname { get; set; }

        public string? image { get; set; }
        [Display(Name ="Image ")]
        public IFormFile? imageuploder { get; set; }


        public virtual IEnumerable<SelectListItem> Categories { get; set; }

    }

}



