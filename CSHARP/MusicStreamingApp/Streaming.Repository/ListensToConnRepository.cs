// <copyright file="ListensToConnRepository.cs" company="PlaceholderCompany">
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
    /// class that implements repository for type conn_listener_song
    /// </summary>
    public class ListensToConnRepository : Repository<conn_listener_song>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListensToConnRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public ListensToConnRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for conn_listener_song
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a conn_listener_song</returns>
        public override conn_listener_song GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.connTwo_id == id);
        }
    }
}
