using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string rolename { get; set; }


        
    }
}
