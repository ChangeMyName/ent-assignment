using newsapp.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace newsapp.Models
{
    public class Account : AppUser
    {
        [Key]
        [ForeignKey("Owner")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "This field is required"),
        // Compare("Password", ErrorMessage = "Passwords do not match")
        // DataType(DataType.Password)]
        //public string ComparePassword { get; set; }

        //[ForeignKey("Owner")]
        //public int OwnerId { get; set; }
        public virtual Journalist Owner { get; set; }

        public bool ValidateUser(string username, string password)
        {
            return Username.Equals(username) && Password.Equals(password);
        }

        public override int GetId()
        {
            return Id;
        }
    }
}