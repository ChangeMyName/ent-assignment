using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using newsapp.Data;
using newsapp.Data.remote;
using newsapp.Models;
using newsapp.Data.Entity;

namespace newsapp.Test
{
    [TestClass]
    public class UnitTest1
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
        public void Create_Account_For_Journalist_Should_pass()
        {
            Journalist journalist = new Journalist();
            journalist.FirstName = "Evgen";
            journalist.LastName = "Danilenko";
            journalist.Description = "The best mofo in the universe";
            journalist.Image = "/Content/Images/me.jpg";
            repo.Create(journalist);
            repo.Save();

            Journalist j = repo.GetEntity<Journalist>(x => x.Id == journalist.Id);
            Assert.AreEqual("Evgen", j.FirstName);


            Account acc = new Account();
            acc.Username = "ChangeMyName_";
            acc.Password = "test12345";
            acc.Id = journalist.Id;
            repo.Create(acc);
            repo.Save();

            acc = repo.GetEntity<Account>(x => x.Id == journalist.Id);
            Assert.IsNotNull(acc.Owner);
            Assert.IsTrue(acc.Owner.FirstName == "Evgen" && acc.Owner.LastName == "Danilenko");

            Remove(acc);
            Remove(journalist);
        }

        private void Remove<T>(T obj ) where T: class, IEntity
        {
            repo.Delete(obj);
            repo.Save();
        }
    }
}
