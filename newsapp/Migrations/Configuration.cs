namespace newsapp.Migrations
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArticlesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(newsapp.Data.ArticlesDb context)
        {
            
            context.Countries.AddOrUpdate(cty => cty.Name,
                           new Country() { Name = "Russia", Id = 1},
                           new Country() { Name = "Italy", Id = 2 },
                           new Country() { Name = "Malta", Id = 3 }
                           );

            context.Categories.AddOrUpdate(ctg => ctg.Name,
                new Category() {Name="Overseas", Id = 1 },
                new Category() {Name="Politics", Id = 2 },
                new Category() {Name="Sports", Id = 3 },
                new Category() {Name="Opinions", Id = 4 },
                new Category() {Name="National", Id = 5 },
                new Category() {Name= "Travel", Id = 6 },
                new Category() {Name= "Odd", Id = 7 }
                );

            
            context.Journalists.AddOrUpdate(aut => aut.FirstName,
                new Journalist() {Id=1, Email = "evg@evg.com", Description = "Who dis 1",  FirstName = "Evgeny", LastName = "Danilenko",  Image = "/Content/Images/me.jpg"},
                new Journalist() {Id=2, Email = "evg@evg.com", Description = "Who dis 1", FirstName = "Lucy", LastName = "Surname",  Image = "/Content/Images/girl1.jpg"},
                new Journalist() {Id=3, Email = "evg@evg.com", Description = "Who dis 1", FirstName = "PolarBear", LastName = "Surname", Image = "/Content/Images/me.jpg"}
                );

            context.Accounts.AddOrUpdate(acc => acc.Username,
                new Account() {Id=1, Username = "fishsticks", Password = "test1234"},
                new Account() {Id=2, Username = "lucy1234", Password = "test1234"},
                new Account() {Id = 3, Username = "PolarBear1234", Password = "test1234"}
                );

            context.Articles.AddOrUpdate(art => art.Header,
                new Article()
                {
                    Header = "The Header was set",
                    SubHeader = "sub headers everywhere",
                    Content = "The headers and subheaders are used in all articles.",
                    Description = "A brief description",
                    Image = "/Content/Images/jet.jpg",
                    CategoryId = 2,
                    JournalistId = 2,
                    CountryId = 2,
                    PostedOn = DateTime.Parse("2017-01-01"),
                    IsBreakingNews = true
                },
                new Article()
                {
                    Header = "The Other Header was set",
                    SubHeader = "sub headers everywhere",
                    Content = "The headers and subheaders are used in all articles.",
                    Description = "A brief description",
                    Image = "/Content/Images/jet.jpg",
                    CategoryId = 3,
                    JournalistId = 1,
                    CountryId = 3,
                    PostedOn = DateTime.Parse("2017-01-02")
                },
                new Article()
                {
                    Header = "The Header was set gracefully",
                    SubHeader = "sub headers everywhere",
                    Content = "The headers and subheaders are used in all articles.",
                    Description = "A brief description",
                    Image = "/Content/Images/jet.jpg",
                    CategoryId = 1,
                    JournalistId = 1,
                    CountryId = 1,
                    PostedOn = DateTime.Parse("2017-01-03")
                },
                new Article()
                {
                    Header = "New stuff 2",
                    SubHeader = "sub headers everywhere",
                    Content = "The headers and subheaders are used in all articles.",
                    Description = "A brief description",
                    Image = "/Content/Images/jet.jpg",
                    CategoryId = 2,
                    JournalistId = 1,
                    CountryId = 1,
                    PostedOn = DateTime.Parse("2017-01-04")
                },
                new Article()
                {
                    Header = "New stuff",
                    SubHeader = "sub headers everywhere",
                    Content = "The headers and subheaders are used in all articles.",
                    Description = "A brief description",
                    Image = "/Content/Images/jet.jpg",
                    CategoryId = 2,
                    JournalistId = 1,
                    CountryId = 1,
                    PostedOn = DateTime.Parse("2017-01-01")
                }
                );
        }
    }
}
