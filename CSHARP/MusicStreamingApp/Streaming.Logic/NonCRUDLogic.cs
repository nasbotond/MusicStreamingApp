// <copyright file="NonCRUDLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Data;
    using Streaming.Logic.Interfaces;
    using Streaming.Repository;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// The class which contains the implementation of all non-CRUD methods
    /// </summary>
    public class NonCRUDLogic : INonCRUDLogic
    {
        /// <summary>
        /// Private instance of IRepository of type song
        /// </summary>
        private readonly IRepository<song> songRepository;

        /// <summary>
        /// Private instance of IRepository of type serv
        /// </summary>
        private readonly IRepository<serv> servRepository;

        /// <summary>
        /// Private instance of IRepository of type artist
        /// </summary>
        private readonly IRepository<artist> artistRepository;

        /// <summary>
        /// Private instance of IRepository of type conn_song_service
        /// </summary>
        private readonly IRepository<conn_song_service> playedOnRepository;

        /// <summary>
        /// Private instance of IRepository of type listener
        /// </summary>
        private readonly IRepository<listener> listenerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NonCRUDLogic"/> class.
        /// </summary>
        /// <param name="songRepo">Takes a IRepository of type song as a parameter</param>
        /// <param name="servRepo">Takes a IRepository of type serv as a parameter</param>
        /// <param name="playedOnRepo">Takes a IRepository of type playedOnConn as a parameter</param>
        /// <param name="listRepo">Takes a IRepository of type listener as a parameter</param>
        /// <param name="artistRepo">Takes a IRepository of type artist as a parameter</param>
        public NonCRUDLogic(IRepository<song> songRepo, IRepository<serv> servRepo, IRepository<conn_song_service> playedOnRepo, IRepository<listener> listRepo, IRepository<artist> artistRepo)
        {
            this.songRepository = songRepo;
            this.servRepository = servRepo;
            this.playedOnRepository = playedOnRepo;
            this.listenerRepository = listRepo;
            this.artistRepository = artistRepo;
        }

        /// <summary>
        /// Creates a NonCRUDLogic instance that can be used in the console to access the methods
        /// </summary>
        /// <returns>Returns a NonCRUDLogic instance</returns>
        public static NonCRUDLogic CreateRealLogic()
        {
            StreamingDatabaseEntities ent = new StreamingDatabaseEntities();
            SongRepository sor = new SongRepository(ent);
            ServRepository ser = new ServRepository(ent);
            PlayedOnConnRepository pr = new PlayedOnConnRepository(ent);
            ListenerRepository lr = new ListenerRepository(ent);
            ArtistRepository ar = new ArtistRepository(ent);
            return new NonCRUDLogic(sor, ser, pr, lr, ar);
        }

        /// <summary>
        /// Returns the number of each gender in the listeners table
        /// </summary>
        /// <returns>returns an IEnumerable of type ListenersGroupBy</returns>
        public IEnumerable<ListenersGroupBy> GetNumberOfListenersBasedOnGender()
        {
            var counts = (from list in this.listenerRepository.GetAll()
                          group list by list.listener_gender into g
                          select new ListenersGroupBy
                          {
                              GenderKey = (string)g.Key,
                              GenderCount = (int)g.Count()
                          }).OrderByDescending(x => x.GenderCount);

            return counts;
        }

        /// <summary>
        /// Returns the song with the greatest length in the table
        /// </summary>
        /// <returns>returns an object from a the select statement that has the longest song_length</returns>
        public song GetLongestSong()
        {
            int longestSong = (int)this.songRepository.GetAll().Max(song => song.song_length);
            return this.songRepository.GetAll().SingleOrDefault(song => song.song_length == longestSong);
        }

        /// <summary>
        /// Returns a query of all the services that play the given song
        /// </summary>
        /// <param name="songId">Id number of the song</param>
        /// <returns>returns an instance of enumerator</returns>
        public IEnumerable<serv> GetServicesThatPlayGivenSong(int songId)
        {
            var servSongJoin = from service in this.servRepository.GetAll()
                               join connSong in this.playedOnRepository.GetAll()
                               on service.serv_id equals connSong.connOne_serviceId
                               select new
                               {
                                   service.serv_id,
                                   service.serv_name,
                                   service.serv_website,
                                   service.serv_size,
                                   service.serv_price,
                                   service.serv_country,
                                   connSong.connOne_songId
                               };
            var result = (from finalServ in servSongJoin
                          where finalServ.connOne_songId == songId
                          select new
                          {
                              serv_id = finalServ.serv_id,
                              serv_name = finalServ.serv_name,
                              serv_size = finalServ.serv_size,
                              serv_website = finalServ.serv_website,
                              serv_price = finalServ.serv_price,
                              serv_country = finalServ.serv_country
                          }).ToList().Select(x => new serv
                          {
                              serv_id = x.serv_id,
                              serv_name = x.serv_name,
                              serv_size = x.serv_size,
                              serv_website = x.serv_website,
                              serv_price = x.serv_price,
                              serv_country = x.serv_country
                          });
            return result;
        }

        /// <summary>
        /// Returns the artists that were active after a given date
        /// </summary>
        /// <param name="givenDate">Receives a date from the user as a parameter</param>
        /// <returns>Returns a list of artists as an IEnumerable</returns>
        public IEnumerable<artist> GetArtistsThatReleasedMusicAfterDate(DateTime givenDate)
        {
            var result = (from artists in this.artistRepository.GetAll()
                          join songs in this.songRepository.GetAll()
                          on artists.artist_id equals songs.song_artistId
                          where songs.song_dateReleased > givenDate
                          select new
                          {
                              artist_id = artists.artist_id,
                              artist_name = artists.artist_name,
                              artist_label = artists.artist_label,
                              artist_age = artists.artist_age,
                              artist_gender = artists.artist_gender,
                              artist_genre = artists.artist_genre
                          }).ToList().Select(x => new artist
                          {
                              artist_id = x.artist_id,
                              artist_name = x.artist_name,
                              artist_label = x.artist_label,
                              artist_age = x.artist_age,
                              artist_gender = x.artist_gender,
                              artist_genre = x.artist_genre
                          });
            return result;
        }
    }
}
