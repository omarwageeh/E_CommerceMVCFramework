using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.MVC.Models
{
    public class CustomerLoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
    }
}