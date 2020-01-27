// <copyright file="SongLogicTest.cs" company="PlaceholderCompany">
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
    /// Class that tests the CRUD methods of SongLogic
    /// </summary>
    [TestFixture]
    public class SongLogicTest
    {
        /// <summary>
        /// private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<song>> m;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<song> ls;

        /// <summary>
        /// Private instance of SongLogic
        /// </summary>
        private SongLogic songLogic;

        /// <summary>
        /// Setup method that runs before every test method
        /// </summary>
        [SetUp]
        public void SongSetUp()
        {
            this.ls = new List<song>()
            {
                new song() { song_id = 1, song_title = "one", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 2, song_title = "two", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 3, song_title = "three", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 4, song_title = "four", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 5, song_title = "five", song_album = "one", song_length = 120, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 }
            };

            this.m = new Mock<IRepository<song>>();
            this.m.Setup(x => x.GetAll()).Returns(this.ls.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.ls.Where(x => x.song_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<song>())).Callback((song sng) => this.ls.Remove(sng));
            this.m.Setup(x => x.Update(It.IsAny<song>())).Callback(
                (song sng) =>
                {
                    var a = this.ls.FindIndex(x => x.song_id == sng.song_id);
                    if (a != -1)
                    {
                        this.ls[a] = sng;
                    }
                    else
                    {
                        this.ls.Add(sng);
                    }
                });

            this.songLogic = new SongLogic(this.m.Object);
        }

        /// <summary>
        /// Tests whether GetAll() method returns expected number of entities
        /// </summary>
        [Test]
        public void GetAllReturnsExpectedNumberOfEntites()
        {
            var res = this.songLogic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.ls.Count));
        }

        /// <summary>
        /// Tests whether GetAll() method returns the correct entities
        /// </summary>
        [Test]
        public void GetAllReturnsCorrectEntities()
        {
            var res = this.songLogic.GetAll();
            Assert.That(res, Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that GetAll() is not empty
        /// </summary>
        [Test]
        public void GetAllIsNotEmpty()
        {
            var res = this.songLogic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetById doesn't return null
        /// </summary>
        [Test]
        public void GetByIdDoesNotReturnNull()
        {
            var res = this.songLogic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetById returns the expected value
        /// </summary>
        [Test]
        public void GetByIdReturnsExpectedValue()
        {
            var res = this.songLogic.GetById(1);
            Assert.That(res.song_title, Is.EqualTo("one"));
        }

        /// <summary>
        /// Tests that Delete deletes only one element
        /// </summary>
        [Test]
        public void DeleteRemovesOnlyOneElement()
        {
            this.songLogic.Delete(this.songLogic.GetAll().First());
            Assert.That(this.songLogic.GetAll().Count(), Is.EqualTo(4));
        }

        /// <summary>
        /// Tests that Delete deletes the correct element
        /// </summary>
        [Test]
        public void DeleteElementRemovesExactlyThatElement()
        {
            song sng = this.ls.First();
            this.ls.RemoveAt(this.ls.FindIndex(x => x.song_id == 1));
            this.songLogic.Delete(sng);
            Assert.That(this.songLogic.GetAll(), Is.EqualTo(this.ls));
        }

        /// <summary>
        /// Tests that Update updates the element correctly
        /// </summary>
        [Test]
        public void UpdateChangesExistingEntityCorrectly()
        {
            this.songLogic.Update(new song { song_id = 1, song_title = "newSong", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 });
            Assert.That(this.songLogic.GetById(1).song_title, Is.EqualTo("newSong"));
        }

        /// <summary>
        /// Tests that Update adds a new element when no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMatchingIsFound()
        {
            this.songLogic.Update(new song { song_id = 6, song_title = "newSong", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 });
            Assert.That(this.songLogic.GetAll().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that Update adds a new element correctly if no matching element is found
        /// </summary>
        [Test]
        public void UpdateAddsNewElementWhenNoneMathingIsFoundAsExpected()
        {
            this.songLogic.Update(new song { song_id = 6, song_title = "newSong", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 });
            Assert.That(this.songLogic.GetById(6).song_title, Is.EqualTo("newSong"));
        }
    }
}
