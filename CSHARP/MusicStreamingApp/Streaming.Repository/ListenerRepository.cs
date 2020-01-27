// <copyright file="ListenerRepository.cs" company="PlaceholderCompany">
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
    /// class that implements repository for type listener
    /// </summary>
    public class ListenerRepository : Repository<listener>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListenerRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public ListenerRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for listener
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a listener</returns>
        public override listener GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.listener_id == id);
        }
    }
}
