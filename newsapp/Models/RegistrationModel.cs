using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newsapp.Models
{

    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 4, ErrorMessage = "Invalid username length")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long."),
         DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; } = false;

    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 4, ErrorMessage = "Invalid username length")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long."),
         DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required"),
         Compare("Password", ErrorMessage = "Passwords do not match")
         DataType(DataType.Password)]
        public string ComparePassword { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 16, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 16 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 16, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 16 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required"),
         DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required"),
         DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        public string Image { get; set; }


    }
}