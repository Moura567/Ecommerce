using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class UserRoleViewModel
    {
        [Display(Name = "Email")]

        public string email { get; set; }
        [Display(Name = "Name")]

        public string name { get; set; }
        [Display(Name ="Select Role")]
        public string roleid { get; set; }
    }
}
