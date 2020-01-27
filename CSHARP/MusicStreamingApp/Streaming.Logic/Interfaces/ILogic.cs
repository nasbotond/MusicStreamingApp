// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Repository;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// ILogic interface that extends the IRepository interface
    /// </summary>
    /// <typeparam name="T">this is a generic interface so it can be used with all tables</typeparam>
    public interface ILogic<T> : IRepository<T>
        where T : class
    {
    }
}
