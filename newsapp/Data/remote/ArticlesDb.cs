using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace newsapp.Data
{
    public class ArticlesDb : DbContext
    {

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Journalist> Journalists { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        public ArticlesDb() : base("ArticlesDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journalist>();
            modelBuilder.Entity<Country>();
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Account>();
        }
    }
}