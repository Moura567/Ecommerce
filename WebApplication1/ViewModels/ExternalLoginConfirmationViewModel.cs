﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
            [EmailAddress]
            public string Email { get; set; }
        

    }
}
