using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using newsapp.Data;
using newsapp.Data.remote;
using newsapp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace newsapp.Test
{
    [TestClass]
    public class TestCategoryModel
    {
        IRepository repo;
        ArticlesDb db;

        [TestInitialize]
        public void Init()
        {
            db = new ArticlesDb();
            repo = new GenericRepository<ArticlesDb>(db);

        }

        [TestMethod]
        public void Test_Get_All_Categories_Should_Pass()
        {
            IEnumerable<Category> cats = repo.GetAll<Category>();
            Assert.IsTrue(cats.Count() > 0);
        }


        [TestMethod]
        public void Test_Get_Articles_That_Are_Older_Than_DateTime_Should_Pass()
        {
            DateTime PostedOn = DateTime.Parse("2017-01-04");
            IEnumerable<Category> categories = repo.GetAll<Category>();
            Category category = categories.FirstOrDefault();
            IEnumerable<Article> articles = category.GetEntitiesOlderThan(PostedOn, category.Articles);
            Assert.IsTrue(articles.Count() > 0);
        }

        [TestMethod]
        public void Test_Get_Latest_Article_From_Category_Should_Pass()
        {
            Category category = repo.GetEntity<Category>(x => x.Id == 2);

            Article article = category.GetLatestEntity(category.Articles);

            Assert.IsNotNull(article);
            Assert.AreEqual(article.PostedOn, DateTime.Parse("2017-01-04"));
        }


    }
}
