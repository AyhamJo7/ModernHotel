using System;
using System.Threading.Tasks;
using ModernHotel.Core.Entities;

namespace ModernHotel.Core.Interfaces
{
    /// <summary>
    /// Interface for the Unit of Work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository for Room entities
        /// </summary>
        IRepository<Room> Rooms { get; }

        /// <summary>
        /// Gets the repository for RoomType entities
        /// </summary>
        IRepository<RoomType> RoomTypes { get; }

        /// <summary>
        /// Gets the repository for Customer entities
        /// </summary>
        IRepository<Customer> Customers { get; }

        /// <summary>
        /// Gets the repository for Booking entities
        /// </summary>
        IRepository<Booking> Bookings { get; }

        /// <summary>
        /// Gets the repository for Service entities
        /// </summary>
        IRepository<Service> Services { get; }

        /// <summary>
        /// Gets the repository for ServiceType entities
        /// </summary>
        IRepository<ServiceType> ServiceTypes { get; }

        /// <summary>
        /// Gets the repository for BookingService entities
        /// </summary>
        IRepository<BookingService> BookingServices { get; }

        /// <summary>
        /// Gets the repository for User entities
        /// </summary>
        IRepository<User> Users { get; }

        /// <summary>
        /// Gets the repository for Bill entities
        /// </summary>
        IRepository<Bill> Bills { get; }

        /// <summary>
        /// Saves all changes made through the repositories to the database
        /// </summary>
        /// <returns>Number of affected rows</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Begins a transaction
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commits the transaction
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rolls back the transaction
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
