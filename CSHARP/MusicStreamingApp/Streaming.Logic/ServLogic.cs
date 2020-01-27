// <copyright file="ServLogic.cs" company="PlaceholderCompany">
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
    using Streaming.Repository;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// ServLogic class that extends Logic and gives T a type (serv)
    /// </summary>
    public class ServLogic : Logic<serv>
    {
        /// <summary>
        /// Private instance of IRepository
        /// </summary>
        private readonly IRepository<serv> servRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServLogic"/> class.
        /// Constructor for ServLogic
        /// </summary>
        /// <param name="repository"> takes a repository of type serv as an argument</param>
        public ServLogic(IRepository<serv> repository)
            : base(repository)
        {
            this.servRepository = repository;
        }

        /// <summary>
        /// Makes it possible to access ServLogic in the Console
        /// </summary>
        /// <returns>Returns a ServLogic instance</returns>
        public static ServLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            ServRepository sr = new ServRepository(se);
            return new ServLogic(sr);
        }
    }
}
