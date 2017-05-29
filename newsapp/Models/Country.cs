using System;
using newsapp.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using newsapp.Data;
using System.Web.Mvc;

namespace newsapp.Models
{
    public partial class Country : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Country")]
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Country()
        {
        }

        public static IEnumerable<SelectListItem> GetAllCountries(IRepository repo)
        {
            
            List<SelectListItem> tmp = new List<SelectListItem>();
            foreach (var item in repo.GetAll<Country>())
            {
                tmp.Add(new SelectListItem() {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return tmp;
        }
    }
}