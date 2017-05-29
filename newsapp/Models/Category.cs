using System;
using newsapp.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using newsapp.Models;
using newsapp.Data;
using System.Linq;
using newsapp.Data.remote;
using System.Web.Mvc;

namespace newsapp.Models
{
    public partial class Category : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Category")]
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public static IEnumerable<SelectListItem> GetAllCategories(IRepository repo)
        {
            List<SelectListItem> tmp = new List<SelectListItem>();
            foreach (var item in repo.GetAll<Category>())
            {
                tmp.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return tmp;
        }

    }
}