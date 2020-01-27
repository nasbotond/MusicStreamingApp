// <copyright file="ServRepository.cs" company="PlaceholderCompany">
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
    /// class that implements repository for type serv
    /// </summary>
    public class ServRepository : Repository<serv>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServRepository"/> class.
        /// </summary>
        /// <param name="context">takes a DbContext as a parameter</param>
        public ServRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// overridden getById method for serv
        /// </summary>
        /// <param name="id">int id </param>
        /// <returns>returns a serv</returns>
        public override serv GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.serv_id == id);
        }
    }
}
