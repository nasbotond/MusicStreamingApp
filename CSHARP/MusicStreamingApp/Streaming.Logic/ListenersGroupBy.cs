// <copyright file="ListenersGroupBy.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Class that defines what a ListenerGroupBy is
    /// </summary>
    public class ListenersGroupBy
    {
        /// <summary>
        /// Gets or sets the GenderKey field
        /// </summary>
        public string GenderKey { get; set; }

        /// <summary>
        /// Gets or sets the GenderCount field
        /// </summary>
        public int GenderCount { get; set; }

        /// <summary>
        /// ToString() override for ListenersGroupBy
        /// </summary>
        /// <returns>returns a string</returns>
        public override string ToString()
        {
            return $"{this.GenderKey}: {this.GenderCount}";
        }
    }
}
