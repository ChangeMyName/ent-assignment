using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newsapp.Models
{
    public partial class Journalist : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 16, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 16 characters long")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required"),
         StringLength(maximumLength: 16, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 16 characters long")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "This field is required"),
         DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required"),
         DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        public string Image { get; set; }

        //public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Journalist () { }
    }
}