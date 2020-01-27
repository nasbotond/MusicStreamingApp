// <copyright file="ListenerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Streaming.Data;
    using Streaming.Logic.Interfaces;
    using Streaming.Repository;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// Logic class that extends Logic and assigns a type to T
    /// </summary>
    public class ListenerLogic : Logic<listener>
    {
        /// <summary>
        /// Private instance of IRepository
        /// </summary>
        private readonly IRepository<listener> listenerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListenerLogic"/> class.
        /// Constructor that essentially just assigns a type to T from Logic
        /// </summary>
        /// <param name="repository"> Takes a repository of type listener as an argument </param>
        public ListenerLogic(IRepository<listener> repository)
            : base(repository)
        {
            this.listenerRepository = repository;
        }

        /// <summary>
        /// Makes it possible to access ListenerLogic in the Console
        /// </summary>
        /// <returns>Returns a ListenerLogic instance</returns>
        public static ListenerLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            ListenerRepository lr = new ListenerRepository(se);
            return new ListenerLogic(lr);
        }
    }
}
