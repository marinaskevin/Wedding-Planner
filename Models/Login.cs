using System;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string LoginEmail { get; set; }
 
        [Required]
        [MinLength(8)]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}