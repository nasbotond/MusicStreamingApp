// <copyright file="ListensToConnLogicTest.cs" company="PlaceholderCompany">
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
    /// Class that tests the CRUD methods of ListensToConnLogic
    /// </summary>
    [TestFixture]
    public class ListensToConnLogicTest
    {
        /// <summary>
        /// private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<conn_listener_song>> m;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<conn_listener_song> ls;

        /// <summary>
        /// Private instance of ListensToConnLogic
        /// </summary>
        private ListensToConnLogic listensToConnLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void ListensToConnSetUp()
        {
            this.ls = new List<conn_listener_song>()
            {
                new conn_listener_song() { connTwo_id = 1, connTwo_listenerId = 3, connTwo_songId = 100 },
                new conn_listener_song() { connTwo_id = 2, connTwo_listenerId = 3, connTwo_songId = 2 },
                new conn_listener_song() { connTwo_id = 3, connTwo_listenerId = 3, connTwo_songId = 2 },
                new conn_listener_song() { connTwo_id = 4, connTwo_listenerId = 3, connTwo_songId = 2 },
                new conn_listener_song() { connTwo_id = 5, connTwo_listenerId = 3, connTwo_songId = 2 }
            };

            this.m = new Mock<IRepository<conn_listener_song>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.connTwo_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<conn_listener_song>())).Callback((conn_listener_song connLS) => this.ls.Remove(connLS));
            this.m.Setup(x => x.Update(It.IsAny<conn_listener_song>())).Callback(
                (conn_listener_song connLS) =>
                {
                    var a = this.ls.FindIndex(x => x.connTwo_id == connLS.connTwo_id);
                    if (a != -1)
                    {
                        this.ls[a] = connLS;
                    }
                    else
                    {
                        this.ls.Add(connLS);
                    }
                });
            this.listensToConnLogic = new ListensToConnLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.listensToConnLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.listensToConnLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.listensToConnLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.listensToConnLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.listensToConnLogic.GetById(1);
            Assert.That(res.connTwo_songId, Is.EqualTo(100));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.listensToConnLogic.Delete(this.listensToConnLogic.GetAll().First());
            Assert.That(this.listensToConnLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            conn_listener_song connLS = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.connTwo_id == 1));
            this.listensToConnLogic.Delete(connLS);
            Assert.That(this.listensToConnLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.listensToConnLogic.Update(new conn_listener_song { connTwo_id = 1, connTwo_listenerId = 55, connTwo_songId = 100 });
            Assert.That(this.listensToConnLogic.GetById(1).connTwo_listenerId, Is.EqualTo(55));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.listensToConnLogic.Update(new conn_listener_song { connTwo_id = 6, connTwo_listenerId = 3, connTwo_songId = 100 });
            Assert.That(this.listensToConnLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMathingIsFoundAsExpected()
        {
            this.listensToConnLogic.Update(new conn_listener_song { connTwo_id = 6, connTwo_listenerId = 55, connTwo_songId = 100 });
            Assert.That(this.listensToConnLogic.GetById(6).connTwo_listenerId, Is.EqualTo(55));
        }
    }
}
