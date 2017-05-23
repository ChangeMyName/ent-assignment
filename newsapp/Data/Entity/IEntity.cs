using newsapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsapp.Data.Entity
{
    public class AppUser : BaseEntity
    {

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 4, ErrorMessage = "Invalid username length"),
         Index(IsUnique = true)]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long."),
         DataType(DataType.Password)]
        public string Password { get; set; }


        public virtual int GetId()
        {
            return -1;
        }

    }
    public interface IEntity
    {
        void GenerateId();
        bool Validate();
    }
}
