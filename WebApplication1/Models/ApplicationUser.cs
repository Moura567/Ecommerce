using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? address{ get; set; }
        public string fullname{ get; set; }

        public int CartId {  get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

    }
}
