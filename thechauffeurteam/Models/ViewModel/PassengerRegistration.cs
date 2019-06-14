using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace thechauffeurteam.Models.ViewModel
{
    public class PassengerRegistration
    {
        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public String UserFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public String UserLastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String UserEmail { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public String UserPhNo { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public String ConformPassword { get; set; }

    }
}