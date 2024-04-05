﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly TitanWebContext _context;

        public GenericRepository(TitanWebContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add Entity To DB
        /// </summary>
        /// <param name="entity"> Entity in DB </param>
        /// <returns> Added Entity </returns>
        /// <exception cref="Exception"></exception>
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Get All Data Entity In DB
        /// </summary>
        /// <returns> A List Of Data Entity </returns>
        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get Data Entity By Id
        /// </summary>
        /// <param name="id"> Id of entity want to get </param>
        /// <returns> Entity Has Id want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Get Data Entity By Id with optional includes
        /// </summary>
        /// <param name="id">Id of the entity to get</param>
        /// <param name="includeProperties">An optional array of properties to include in the query</param>
        /// <returns>The entity that matches the specified Id, if it exists. Returns null if the entity does not exist in the database.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
