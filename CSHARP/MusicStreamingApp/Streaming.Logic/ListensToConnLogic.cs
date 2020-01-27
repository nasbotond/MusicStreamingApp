// <copyright file="ListensToConnLogic.cs" company="PlaceholderCompany">
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
    /// Class ListensToConnLogic that extends the Logic class and implements with type conn_listener_song
    /// </summary>
    public class ListensToConnLogic : Logic<conn_listener_song>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListensToConnLogic"/> class.
        /// Constructor for ListensToConnLogic
        /// </summary>
        /// <param name="repository">takes a Repository of type conn_listener_song as an argument</param>
        public ListensToConnLogic(IRepository<conn_listener_song> repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Makes it possible to access ListensToConnLogic in the Console
        /// </summary>
        /// <returns>Returns a ListensToConnLogic instance</returns>
        public static ListensToConnLogic CreateRealLogic()
        {
            StreamingDatabaseEntities se = new StreamingDatabaseEntities();
            ListensToConnRepository ltcr = new ListensToConnRepository(se);
            return new ListensToConnLogic(ltcr);
        }
    }
}
