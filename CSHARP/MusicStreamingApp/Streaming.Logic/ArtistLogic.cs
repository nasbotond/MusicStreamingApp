// <copyright file="ArtistLogic.cs" company="PlaceholderCompany">
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
    /// Class ArtistLogic that implements Logic with type artist
    /// </summary>
    public class ArtistLogic : Logic<artist>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistLogic"/> class.
        /// Constructor for ArtistLogic class by calling the base class constructor
        /// </summary>
        /// <param name="repository">takes a repository of type artist as an argument</param>
        public ArtistLogic(IRepository<artist> repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Makes it possible to access ArtistLogic in the Console
        /// </summary>
        /// <returns>Returns an ArtistLogic instance</returns>
        public static ArtistLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            ArtistRepository ar = new ArtistRepository(se);
            return new ArtistLogic(ar);
        }
    }
}
