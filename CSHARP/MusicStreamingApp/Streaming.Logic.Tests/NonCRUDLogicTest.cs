// <copyright file="NonCRUDLogicTest.cs" company="PlaceholderCompany">
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
    /// Tests the non CRUD methods
    /// </summary>
    [TestFixture]
    public class NonCRUDLogicTest
    {
        /// <summary>
        /// Private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<song>> s;

        /// <summary>
        /// Private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<serv>> m;

        /// <summary>
        /// Private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<conn_song_service>> n;

        /// <summary>
        /// Private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<artist>> a;

        /// <summary>
        /// Private instance of a Mock of IRepository
        /// </summary>
        private Mock<IRepository<listener>> l;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<serv> servLs;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<conn_song_service> connLs;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<song> songLs;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<artist> artistLs;

        /// <summary>
        /// Private instance of a List
        /// </summary>
        private List<listener> listLs;

        /// <summary>
        /// Private instance of NonCRUDLogic
        /// </summary>
        private NonCRUDLogic logic;

        /// <summary>
        /// Setup method called before every test method
        /// </summary>
        [SetUp]
        public void NonCRUDSetup()
        {
            this.songLs = new List<song>()
            {
                new song() { song_id = 1, song_title = "one", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("1930-01-01"), song_artistId = 1 },
                new song() { song_id = 2, song_title = "two", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 3, song_title = "three", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2002-01-01"), song_artistId = 1 },
                new song() { song_id = 4, song_title = "four", song_album = "one", song_length = 100, song_explicit = true, song_dateReleased = DateTime.Parse("2001-01-01"), song_artistId = 1 },
                new song() { song_id = 5, song_title = "five", song_album = "one", song_length = 120, song_explicit = true, song_dateReleased = DateTime.Parse("2005-01-01"), song_artistId = 5 }
            };

            this.s = new Mock<IRepository<song>>();
            this.s.Setup(x => x.GetAll()).Returns(this.songLs.AsQueryable());
            this.s.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.songLs.Where(x => x.song_id == id).FirstOrDefault());
            this.s.Setup(x => x.Delete(It.IsAny<song>())).Callback((song sng) => this.songLs.Remove(sng));
            this.s.Setup(x => x.Update(It.IsAny<song>())).Callback(
                (song sng) =>
                {
                    var a = this.songLs.FindIndex(x => x.song_id == sng.song_id);
                    if (a != -1)
                    {
                        this.songLs[a] = sng;
                    }
                    else
                    {
                        this.songLs.Add(sng);
                    }
                });

            this.servLs = new List<serv>()
            {
                new serv() { serv_id = 1, serv_name = "one", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 2, serv_name = "two", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 3, serv_name = "three", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 4, serv_name = "four", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" },
                new serv() { serv_id = 5, serv_name = "five", serv_size = 100, serv_website = "website", serv_price = 10, serv_country = "one" }
            };

            this.m = new Mock<IRepository<serv>>();
            this.m.Setup(x => x.GetAll()).Returns(this.servLs.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.servLs.Where(x => x.serv_id == id).FirstOrDefault());
            this.m.Setup(x => x.Delete(It.IsAny<serv>())).Callback((serv serv) => this.servLs.Remove(serv));
            this.m.Setup(x => x.Update(It.IsAny<serv>())).Callback(
                (serv serv) =>
                {
                    var a = this.servLs.FindIndex(x => x.serv_id == serv.serv_id);
                    if (a != -1)
                    {
                        this.servLs[a] = serv;
                    }
                    else
                    {
                        this.servLs.Add(serv);
                    }
                });

            this.connLs = new List<conn_song_service>()
            {
                new conn_song_service() { connOne__id = 1, connOne_songId = 1, connOne_serviceId = 2 },
                new conn_song_service() { connOne__id = 2, connOne_songId = 2, connOne_serviceId = 3 },
                new conn_song_service() { connOne__id = 3, connOne_songId = 1, connOne_serviceId = 2 },
                new conn_song_service() { connOne__id = 4, connOne_songId = 4, connOne_serviceId = 4 },
                new conn_song_service() { connOne__id = 5, connOne_songId = 4, connOne_serviceId = 5 },
                new conn_song_service() { connOne__id = 6, connOne_songId = 3, connOne_serviceId = 1 },
                new conn_song_service() { connOne__id = 7, connOne_songId = 6, connOne_serviceId = 5 }
            };
            this.n = new Mock<IRepository<conn_song_service>>();
            this.n.Setup(x => x.GetAll()).Returns(this.connLs.AsQueryable());
            this.n.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.connLs.Where(x => x.connOne__id == id).FirstOrDefault());
            this.n.Setup(x => x.Delete(It.IsAny<conn_song_service>())).Callback((conn_song_service conn) => this.connLs.Remove(conn));
            this.n.Setup(x => x.Update(It.IsAny<conn_song_service>())).Callback(
                (conn_song_service conn) =>
                {
                    var a = this.connLs.FindIndex(x => x.connOne__id == conn.connOne__id);
                    if (a != -1)
                    {
                        this.connLs[a] = conn;
                    }
                    else
                    {
                        this.connLs.Add(conn);
                    }
                });

            this.artistLs = new List<artist>()
            {
                new artist() { artist_id = 1, artist_name = "one", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 2, artist_name = "two", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 3, artist_name = "three", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 4, artist_name = "four", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" },
                new artist() { artist_id = 5, artist_name = "five", artist_label = "one", artist_age = 100, artist_gender = "male", artist_genre = "country" }
            };

            this.a = new Mock<IRepository<artist>>();
            this.a.Setup(x => x.GetAll()).Returns(this.artistLs.AsQueryable());
            this.a.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.artistLs.Where(x => x.artist_id == id).FirstOrDefault());
            this.a.Setup(x => x.Delete(It.IsAny<artist>())).Callback((artist art) => this.artistLs.Remove(art));
            this.a.Setup(x => x.Update(It.IsAny<artist>())).Callback(
                (artist art) =>
                {
                    var a = this.artistLs.FindIndex(x => x.artist_id == art.artist_id);
                    if (a != -1)
                    {
                        this.artistLs[a] = art;
                    }
                    else
                    {
                        this.artistLs.Add(art);
                    }
                });

            this.listLs = new List<listener>()
            {
                new listener() { listener_id = 1, listener_name = "one", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" },
                new listener() { listener_id = 2, listener_name = "two", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "female" },
                new listener() { listener_id = 3, listener_name = "three", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" },
                new listener() { listener_id = 4, listener_name = "four", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "female" },
                new listener() { listener_id = 5, listener_name = "five", listener_country = "one", listener_deviceType = "PC", listener_email = "blahblah@gmail.com", listener_gender = "male" }
            };

            this.l = new Mock<IRepository<listener>>();
            this.l.Setup(x => x.GetAll()).Returns(this.listLs.AsQueryable());
            this.l.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.listLs.Where(x => x.listener_id == id).FirstOrDefault());
            this.l.Setup(x => x.Delete(It.IsAny<listener>())).Callback((listener lst) => this.listLs.Remove(lst));
            this.l.Setup(x => x.Update(It.IsAny<listener>())).Callback(
                (listener lst) =>
                {
                    var a = this.listLs.FindIndex(x => x.listener_id == lst.listener_id);
                    if (a != -1)
                    {
                        this.listLs[a] = lst;
                    }
                    else
                    {
                        this.listLs.Add(lst);
                    }
                });
            this.logic = new NonCRUDLogic(this.s.Object, this.m.Object, this.n.Object, this.l.Object, this.a.Object);
        }

        /// <summary>
        /// Tests that NumberOfListenersBasedOnGender is not null or empty
        /// </summary>
        [Test]
        public void TestGetNumberOfListenersBasedOnGenderIsNotNullOrEmpty()
        {
            var res = this.logic.GetNumberOfListenersBasedOnGender();
            Assert.That(res, Is.Not.Null);
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Tests that NumberOfListenersBasedOnGender works correctly
        /// </summary>
        [Test]
        public void TestGetNumberOfListenersBasedOnGenderCountsGendersCorrectly()
        {
            List<ListenersGroupBy> list = new List<ListenersGroupBy>();
            foreach (ListenersGroupBy item in this.logic.GetNumberOfListenersBasedOnGender())
            {
                list.Add(item);
            }

            Assert.That(list.First().GenderCount, Is.EqualTo(3));
        }

        /// <summary>
        /// Tests that GetServicesThatPlayGivenSong is not null or empty
        /// </summary>
        [Test]
        public void TestGetServicesThatPlayGivenSongIsNotNullOrEmpty()
        {
            Assert.That(this.logic.GetServicesThatPlayGivenSong(2), Is.Not.Null);
            Assert.That(this.logic.GetServicesThatPlayGivenSong(2), Is.Not.Empty);
        }

        /// <summary>
        /// Tests that GetServicesThatPlayGivenSong returns with the correct size
        /// </summary>
        [Test]
        public void TestGetServicesThatPlayGivenSongReturnsWithCorrectSize()
        {
            Assert.That(this.logic.GetServicesThatPlayGivenSong(4).Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Tests that GetLongestSong returns with the correct song
        /// </summary>
        [Test]
        public void TestGetLongestSongReturnsCorrectSong()
        {
            var res = this.logic.GetLongestSong();

            Assert.That(res.song_id, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests that GetLongestSong returns with only one song
        /// </summary>
        [Test]
        public void TestGetLongestSongReturnsOnlyOneSong()
        {
            var res = this.logic.GetLongestSong();
            Assert.That(res.GetType(), Is.EqualTo(typeof(song)));
        }

        /// <summary>
        /// Tests that GetArtistsThatReleaseMusicAfterDate returns with correct size
        /// </summary>
        /// <param name="date">Takes a date as a parameter</param>
        /// <returns>returns the number of artists that released music past the given date</returns>
        [TestCase("01/01/1900", ExpectedResult = 5)]
        [TestCase("01/01/2000", ExpectedResult = 4)]
        [TestCase("01/01/2004", ExpectedResult = 1)]
        public int TestGetArtistsThatReleasedMusicAfterDateReturnsWithCorrectSize(DateTime date)
        {
            return this.logic.GetArtistsThatReleasedMusicAfterDate(date).Count();
        }

        /// <summary>
        /// Tests that GetArtistsThatReleaseMusicAfterDate returns with correct element
        /// </summary>
        [Test]
        public void TestGetArtistsThatReleasedMusicAfterDateReturnsWithCorrectElement()
        {
            DateTime d = new DateTime(2004, 1, 1);
            Assert.That(this.logic.GetArtistsThatReleasedMusicAfterDate(d).Single().artist_name, Is.EqualTo("five"));
        }
    }
}
