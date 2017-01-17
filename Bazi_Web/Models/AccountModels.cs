using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazi_Web.Models
{
    public class LogInViewModel
    {
        [Required(AllowEmptyStrings =false, 
            ErrorMessage = "Please enter your username")]
        [Display(Name = "Username:")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }
}