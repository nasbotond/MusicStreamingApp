// <copyright file="Logic.cs" company="PlaceholderCompany">
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
    /// Logic class that implements CRUD methods in the Logic layer
    /// </summary>
    /// <typeparam name="T"> generic type so it can be implemented for all DB types </typeparam>
    public class Logic<T> : ILogic<T>
        where T : class
    {
        /// <summary>
        /// Private instance of generic IRepository
        /// </summary>
        private readonly IRepository<T> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic{T}"/> class.
        /// Constructor for Logic that takes a repository as an argument
        /// </summary>
        /// <param name="repository"> takes a repository as an argument </param>
        public Logic(IRepository<T> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Delete method implementation in the logic layer
        /// </summary>
        /// <param name="element"> A T type element </param>
        public void Delete(T element)
        {
            this.repository.Delete(element);
        }

        /// <summary>
        /// GetAll method implementation in the Logic layer
        /// </summary>
        /// <returns> returns a DbSet </returns>
        public IQueryable<T> GetAll()
        {
            return this.repository.GetAll();
        }

        /// <summary>
        /// GetById implementation in the Logic class
        /// </summary>
        /// <param name="id">takes int id as parameter</param>
        /// <returns>returns an element of type T</returns>
        public T GetById(int id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Insert method implementation in the Logic layer
        /// </summary>
        /// <param name="element"> T type element </param>
        public void Insert(T element)
        {
            this.repository.Insert(element);
        }

        /// <summary>
        /// Update method implementation in the Logic layer
        /// </summary>
        /// <param name="element"> T type element </param>
        public void Update(T element)
        {
            this.repository.Update(element);
        }
    }
}
