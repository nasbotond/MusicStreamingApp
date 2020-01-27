// <copyright file="ArtistRepository.cs" company="PlaceholderCompany">
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
    /// class that implements repository for type artist
    /// </summary>
    public class ArtistRepository : Repository<artist>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public ArtistRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for artist
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a artist</returns>
        public override artist GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.artist_id == id);
        }
    }
}
