// <copyright file="SongLogic.cs" company="PlaceholderCompany">
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
    /// Class SongLogic that implements Logic with type song
    /// </summary>
    public class SongLogic : Logic<song>
    {
        /// <summary>
        /// Private instance of IRepository
        /// </summary>
        private readonly IRepository<song> songRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongLogic"/> class.
        /// Constructor for SongLogic that extends Logic
        /// </summary>
        /// <param name="repository">Takes a repository of type song as an argument</param>
        public SongLogic(IRepository<song> repository)
            : base(repository)
        {
            this.songRepository = repository;
        }

        /// <summary>
        /// Makes it possible to access SongLogic in the Console
        /// </summary>
        /// <returns>Returns a SongLogic instance</returns>
        public static SongLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            SongRepository sr = new SongRepository(se);
            return new SongLogic(sr);
        }
    }
}
