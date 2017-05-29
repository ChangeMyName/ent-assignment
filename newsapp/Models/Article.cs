using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace newsapp.Models
{
    public partial class Article : IWithDate
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,
         StringLength(50, MinimumLength = 2, ErrorMessage = "Article heading must be between 2 and 50 characters long")]
        public string Header { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Article sub-heading must be between 2 and 50 characters long")]
        public string SubHeader { get; set; }

        [Required,
         DataType(DataType.Upload)]
        public string Image { get; set; }

        [Required,
         StringLength(255, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 255 characters long")]
        public string Description { get; set; }
        [Required,
         MaxLength(), MinLength(5, ErrorMessage = "Content must be atleast 5 characters long")]
        public string Content { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }

        public bool IsBreakingNews { get; set; }

        public int Views { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int JournalistId { get; set; }
        public virtual Journalist Journalist { get; set; }

        public void GenerateId() { return; }
        public bool Validate() { return true; }

        public DateTime GetDateTime()
        {
            return PostedOn;
        }

        public DateTime GetDateCreated()
        {
            return PostedOn;
        }

        public DateTime GetDateLastModified()
        {
            throw new NotImplementedException();
        }
    }
}