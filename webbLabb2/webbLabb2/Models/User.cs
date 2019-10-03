using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webbLabb2.Models
{
    public class User
    {
        [MaxLength(12), MinLength(4), Required, Key]
        public string UserName { get; set; }
        [MinLength(8), Required]
        public string PasswordUsernameHash { get; set; }
    }
}
