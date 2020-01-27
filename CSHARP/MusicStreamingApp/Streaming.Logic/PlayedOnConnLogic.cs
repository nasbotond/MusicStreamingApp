// <copyright file="PlayedOnConnLogic.cs" company="PlaceholderCompany">
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
    /// Class PlayedOnConnLogic that implements the Logic class with type conn_song_service
    /// </summary>
    public class PlayedOnConnLogic : Logic<conn_song_service>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayedOnConnLogic"/> class.
        /// Constructor for PlayedOnConnLogic that calls base class constructor
        /// </summary>
        /// <param name="repository">takes a repository of type conn_song_service as an argument</param>
        public PlayedOnConnLogic(IRepository<conn_song_service> repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Makes it possible to access PlayedOnConnLogic in the Console
        /// </summary>
        /// <returns>Returns a PlayedONConnLogic instance</returns>
        public static PlayedOnConnLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            PlayedOnConnRepository pocl = new PlayedOnConnRepository(se);
            return new PlayedOnConnLogic(pocl);
        }
    }
}
