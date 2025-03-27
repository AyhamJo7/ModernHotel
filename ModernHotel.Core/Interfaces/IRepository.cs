using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ModernHotel.Core.Entities;

namespace ModernHotel.Core.Interfaces
{
    /// <summary>
    /// Generic repository interface for CRUD operations
    /// </summary>
    /// <typeparam name="T">Entity type that inherits from BaseEntity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>A collection of all entities</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets entities based on a filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>A collection of filtered entities</returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets a single entity by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>The entity if found, otherwise null</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets the first entity that matches the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>The first matching entity if found, otherwise null</returns>
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>The added entity</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity by ID
        /// </summary>
        /// <param name="id">ID of the entity to delete</param>
        /// <returns>True if deletion was successful, otherwise false</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Checks if any entity matches the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>True if any entity matches, otherwise false</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets the count of entities that match the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Count of matching entities</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
