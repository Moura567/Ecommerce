using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; }

        [Length(11,13,ErrorMessage ="Please enter right phone number"),Display(Name ="Phone Number")]
       public string phonenumber {  get; set; }
        [DataType(DataType.EmailAddress)]
       public string Email {  get; set; }

    }
}
