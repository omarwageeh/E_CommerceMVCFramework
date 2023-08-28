using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class User : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
