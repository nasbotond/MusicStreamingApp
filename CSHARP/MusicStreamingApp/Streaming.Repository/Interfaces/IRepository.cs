// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Repository.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// IRepository interface that outlines the CRUD methods
    /// </summary>
    /// <typeparam name="T"> Generic interface </typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Insertion of an element
        /// </summary>
        /// <param name="element">inserts an element of type T</param>
        void Insert(T element);

        /// <summary>
        /// Delete an element
        /// </summary>
        /// <param name="element">deletes the element of type T</param>
        void Delete(T element);

        /// <summary>
        /// Returns all elements
        /// </summary>
        /// <returns>Returns as an evaluable query</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// get element by id
        /// </summary>
        /// <param name="id">takes an integer as a parameter</param>
        /// <returns>returns an element of type T</returns>
        T GetById(int id);

        /// <summary>
        /// Update or change an element
        /// </summary>
        /// <param name="element">updates the element of type T in the set</param>
        void Update(T element);
    }
}
