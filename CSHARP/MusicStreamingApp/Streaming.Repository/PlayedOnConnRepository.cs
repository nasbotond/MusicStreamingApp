// <copyright file="PlayedOnConnRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Data;

    /// <summary>
    /// class that implements repository for type conn_song_service
    /// </summary>
    public class PlayedOnConnRepository : Repository<conn_song_service>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayedOnConnRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public PlayedOnConnRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for conn_song_service
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a conn_song_service</returns>
        public override conn_song_service GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.connOne__id == id);
        }
    }
}
