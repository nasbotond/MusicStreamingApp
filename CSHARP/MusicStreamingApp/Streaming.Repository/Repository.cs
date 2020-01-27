// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Streaming.Repository.Interfaces;

    /// <summary>
    /// Repository class that implements the IRepository generic interface
    /// </summary>
    /// <typeparam name="T"> Generic type T so it can be used with all tables in the DB </typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// A private instance of DbContext
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// Constructor for a repository that takes a DbContext as a parameter
        /// </summary>
        /// <param name="context">Takes a DbContext as an argument</param>
        public Repository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the value of Context
        /// </summary>
        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Implementation of the Delete function that takes an element as a parameter
        /// </summary>
        /// <param name="element"> takes an element of type T as an argument so it can delete that element from the set </param>
        public void Delete(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Remove(element);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Implemented GetAll method that returns all elements as a query set
        /// </summary>
        /// <returns>Returns a DBSet with all the elements</returns>
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// gets element by Id
        /// </summary>
        /// <param name="id">int id is the id of the element in the set</param>
        /// <returns>returns a type T</returns>
        public abstract T GetById(int id);

        /// <summary>
        /// Implemented insert method that has an element as a parameter
        /// </summary>
        /// <param name="element">takes an element of type T as an argument so it can insert that element into the set</param>
        public void Insert(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Add(element);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Implemented Update method that takes an element as a parameter
        /// </summary>
        /// <param name="element">takes an element of type T as an argument so it can update that element in the set</param>
        public void Update(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Attach(element);
            this.context.Entry(element).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
