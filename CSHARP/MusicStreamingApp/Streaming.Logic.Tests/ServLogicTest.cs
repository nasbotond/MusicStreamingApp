// <copyright file="ServLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using Streaming.Data;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// Class that tests the CRUD methods of ServLogic
    /// </summary>
    [TestFixture]
    public class ServLogicTest
    {
        /// <summary>
        /// private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<serv>> m;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<serv> ls;

        /// <summary>
        /// Private instance of ServLogic
        /// </summary>
        private ServLogic servLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void ServSetUp()
        {
            this.ls = new List<serv>()
            {
                new serv() { serv_id = 1, serv_name = "one", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 2, serv_name = "two", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 3, serv_name = "three", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 4, serv_name = "four", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 5, serv_name = "five", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" }
            };

            this.m = new Mock<IRepository<serv>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.serv_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<serv>())).Callback((serv serv) => this.ls.Remove(serv));
            this.m.Setup(x => x.Update(It.IsAny<serv>())).Callback(
                (serv serv) =>
                {
                    var a = this.ls.FindIndex(x => x.serv_id == serv.serv_id);
                    if (a != -1)
                    {
                        this.ls[a] = serv;
                    }
                    else
                    {
                        this.ls.Add(serv);
                    }
                });

            this.servLogic = new ServLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.servLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.servLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.servLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.servLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.servLogic.GetById(1);
            Assert.That(res.serv_name, Is.EqualTo("one"));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.servLogic.Delete(this.servLogic.GetAll().First());
            Assert.That(this.servLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            serv serv = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.serv_id == 1));
            this.servLogic.Delete(serv);
            Assert.That(this.servLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.servLogic.Update(new serv { serv_id = 1, serv_name = "newserv", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" });
            Assert.That(this.servLogic.GetById(1).serv_name, Is.EqualTo("newserv"));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.servLogic.Update(new serv { serv_id = 6, serv_name = "newserv", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" });
            Assert.That(this.servLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMathingIsFoundAsExpected()
        {
            this.servLogic.Update(new serv { serv_id = 6, serv_name = "newserv", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" });
            Assert.That(this.servLogic.GetById(6).serv_name, Is.EqualTo("newserv"));
        }
    }
}
