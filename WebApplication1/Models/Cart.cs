using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Cart
    {

        public int Id { get; set; }
     
        public string UserId { get; set; }

        public DateTime createdat {  get; set; }
        public List<CartItem> Items { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }

}
