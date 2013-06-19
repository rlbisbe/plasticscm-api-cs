using NUnit.Framework;
using PlasticAPI.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticAPI.Tests
{
    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void ListRepositoryTest()
        {
            List<Repository> repos = PlasticProgram.ListRepositories();
            Assert.AreEqual("default", repos[0].Name);
        }

        [Test]
        public void AddNewRepository()
        {
            Repository rep = new Repository();
            rep.Name = "NewRepository";
            rep.Server = "localhost:8087";
            PlasticProgram.CreateRepository(rep);
            //TODO: Return a specific id.
        }

    }
}
