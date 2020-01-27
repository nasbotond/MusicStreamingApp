// <copyright file="ListenerLogicTest.cs" company="PlaceholderCompany">
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
    /// Class that tests the CRUD methods of Listener
    /// </summary>
    [TestFixture]
    public class ListenerLogicTest
    {
        /// <summary>
        /// Mock instance of IRepository listener
        /// </summary>
        private Mock<IRepository<listener>> m;

        /// <summary>
        /// List of type listeners
        /// </summary>
        private List<listener> ls;

        /// <summary>
        /// Private instance of ListenerLogic
        /// </summary>
        private ListenerLogic listenerLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void ListenerSetUp()
        {
            this.ls = new List<listener>()
            {
                new listener() { listener_id = 1, listener_name = "one", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" },
                new listener() { listener_id = 2, listener_name = "two", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "female" },
                new listener() { listener_id = 3, listener_name = "three", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" },
                new listener() { listener_id = 4, listener_name = "four", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "female" },
                new listener() { listener_id = 5, listener_name = "five", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" }
            };

            this.m = new Mock<IRepository<listener>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.listener_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<listener>())).Callback((listener lst) => this.ls.Remove(lst));
            this.m.Setup(x => x.Update(It.IsAny<listener>())).Callback(
                (listener lst) =>
                {
                    var a = this.ls.FindIndex(x => x.listener_id == lst.listener_id);
                    if (a != -1)
                    {
                        this.ls[a] = lst;
                    }
                    else
                    {
                        this.ls.Add(lst);
                    }
                });
            this.listenerLogic = new ListenerLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.listenerLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.listenerLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.listenerLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.listenerLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.listenerLogic.GetById(1);
            Assert.That(res.listener_name, Is.EqualTo("one"));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.listenerLogic.Delete(this.listenerLogic.GetAll().First());
            Assert.That(this.listenerLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            listener lst = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.listener_id == 1));
            this.listenerLogic.Delete(lst);
            Assert.That(this.listenerLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.listenerLogic.Update(new listener { listener_id = 1, listener_name = "newlistener", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" });
            Assert.That(this.listenerLogic.GetById(1).listener_name, Is.EqualTo("newlistener"));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.listenerLogic.Update(new listener { listener_id = 6, listener_name = "newlistener", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" });
            Assert.That(this.listenerLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMathingIsFoundAsExpected()
        {
            this.listenerLogic.Update(new listener { listener_id = 6, listener_name = "newlistener", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" });
            Assert.That(this.listenerLogic.GetById(6).listener_name, Is.EqualTo("newlistener"));
        }
    }
}
