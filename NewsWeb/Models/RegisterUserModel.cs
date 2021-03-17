using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class RegisterUserModel
    {
        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }
        
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email{ get; set; }
        
        [Display(Name = "Repeat e-mail")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email")]
        [Required]
        public string RepeatedEmail{ get; set; }
        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password{ get; set; }
        
        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string RepeatedPassword{ get; set; }
    }
}
