// <copyright file="ArtistLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Streaming.Data;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// Class that tests the CRUD methods of Artist
    /// </summary>
    [TestFixture]
    public class ArtistLogicTest
    {
        /// <summary>
        /// private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<artist>> m;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<artist> ls;

        /// <summary>
        /// Private instance of ArtistLogic
        /// </summary>
        private ArtistLogic artistLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void ArtistSetUp()
        {
            this.ls = new List<artist>()
            {
                new artist() { artist_id = 1, artist_name = "one", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 2, artist_name = "two", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 3, artist_name = "three", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 4, artist_name = "four", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 5, artist_name = "five", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" }
            };

            this.m = new Mock<IRepository<artist>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.artist_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<artist>())).Callback((artist art) => this.ls.Remove(art));
            this.m.Setup(x => x.Update(It.IsAny<artist>())).Callback(
                (artist art) =>
                {
                    var a = this.ls.FindIndex(x => x.artist_id == art.artist_id);
                    if (a != -1)
                    {
                        this.ls[a] = art;
                    }
                    else
                    {
                        this.ls.Add(art);
                    }
                });
            this.artistLogic = new ArtistLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.artistLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.artistLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.artistLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.artistLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.artistLogic.GetById(1);
            Assert.That(res.artist_name, Is.EqualTo("one"));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.artistLogic.Delete(this.artistLogic.GetAll().First());
            Assert.That(this.artistLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            artist art = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.artist_id == 1));
            this.artistLogic.Delete(art);
            Assert.That(this.artistLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.artistLogic.Update(new artist { artist_id = 1, artist_name = "newartist", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" });
            Assert.That(this.artistLogic.GetById(1).artist_name, Is.EqualTo("newartist"));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.artistLogic.Update(new artist { artist_id = 6, artist_name = "newartist", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" });
            Assert.That(this.artistLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFoundAsExpected()
        {
            this.artistLogic.Update(new artist { artist_id = 6, artist_name = "newartist", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" });
            Assert.That(this.artistLogic.GetById(6).artist_name, Is.EqualTo("newartist"));
        }
    }
}
