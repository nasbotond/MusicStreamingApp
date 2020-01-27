// <copyright file="SongRepository.cs" company="PlaceholderCompany">
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
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// class that implements repository for type song
    /// </summary>
    public class SongRepository : Repository<song>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public SongRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for song
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a song</returns>
        public override song GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.song_id == id);
        }
    }
}
