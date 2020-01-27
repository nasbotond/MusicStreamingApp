// <copyright file="PlayedOnConnLogicTest.cs" company="PlaceholderCompany">
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
    /// Class that tests the CRUD methods of PlayedOnConnLogic
    /// </summary>
    [TestFixture]
    public class PlayedOnConnLogicTest
    {
        /// <summary>
        /// private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<conn_song_service>> m;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<conn_song_service> ls;

        /// <summary>
        /// Private instance of PlayedOnConnLogic
        /// </summary>
        private PlayedOnConnLogic playedOnConnLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void PlayedOnConnSetUp()
        {
            this.ls = new List<conn_song_service>()
            {
                new conn_song_service() { connOne__id = 1, connOne_songId = 3, connOne_serviceId = 100 },
                new conn_song_service() { connOne__id = 2, connOne_songId = 3, connOne_serviceId = 2 },
                new conn_song_service() { connOne__id = 3, connOne_songId = 3, connOne_serviceId = 2 },
                new conn_song_service() { connOne__id = 4, connOne_songId = 3, connOne_serviceId = 2 },
                new conn_song_service() { connOne__id = 5, connOne_songId = 3, connOne_serviceId = 2 }
            };

            this.m = new Mock<IRepository<conn_song_service>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.connOne__id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<conn_song_service>())).Callback((conn_song_service connSS) => this.ls.Remove(connSS));
            this.m.Setup(x => x.Update(It.IsAny<conn_song_service>())).Callback(
                (conn_song_service connSS) =>
                {
                    var a = this.ls.FindIndex(x => x.connOne__id == connSS.connOne__id);
                    if (a != -1)
                    {
                        this.ls[a] = connSS;
                    }
                    else
                    {
                        this.ls.Add(connSS);
                    }
                });
            this.playedOnConnLogic = new PlayedOnConnLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.playedOnConnLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.playedOnConnLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.playedOnConnLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.playedOnConnLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.playedOnConnLogic.GetById(1);
            Assert.That(res.connOne_serviceId, Is.EqualTo(100));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.playedOnConnLogic.Delete(this.playedOnConnLogic.GetAll().First());
            Assert.That(this.playedOnConnLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            conn_song_service connSS = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.connOne__id == 1));
            this.playedOnConnLogic.Delete(connSS);
            Assert.That(this.playedOnConnLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.playedOnConnLogic.Update(new conn_song_service { connOne__id = 1, connOne_songId = 55, connOne_serviceId = 100 });
            Assert.That(this.playedOnConnLogic.GetById(1).connOne_songId, Is.EqualTo(55));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.playedOnConnLogic.Update(new conn_song_service { connOne__id = 6, connOne_songId = 3, connOne_serviceId = 100 });
            Assert.That(this.playedOnConnLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMathingIsFoundAsExpected()
        {
            this.playedOnConnLogic.Update(new conn_song_service { connOne__id = 6, connOne_songId = 55, connOne_serviceId = 100 });
            Assert.That(this.playedOnConnLogic.GetById(6).connOne_songId, Is.EqualTo(55));
        }
    }
}
