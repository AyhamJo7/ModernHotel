using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModernHotel.Core.Entities;
using ModernHotel.Core.Interfaces;
using ModernHotel.Infrastructure.Data;

namespace ModernHotel.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the Unit of Work pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        private IRepository<Room> _roomRepository;
        private IRepository<RoomType> _roomTypeRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Booking> _bookingRepository;
        private IRepository<Service> _serviceRepository;
        private IRepository<ServiceType> _serviceTypeRepository;
        private IRepository<BookingService> _bookingServiceRepository;
        private IRepository<User> _userRepository;
        private IRepository<Bill> _billRepository;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class
        /// </summary>
        /// <param name="context">The database context</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public IRepository<Room> Rooms => _roomRepository ??= new Repository<Room>(_context);

        /// <inheritdoc/>
        public IRepository<RoomType> RoomTypes => _roomTypeRepository ??= new Repository<RoomType>(_context);

        /// <inheritdoc/>
        public IRepository<Customer> Customers => _customerRepository ??= new Repository<Customer>(_context);

        /// <inheritdoc/>
        public IRepository<Booking> Bookings => _bookingRepository ??= new Repository<Booking>(_context);

        /// <inheritdoc/>
        public IRepository<Service> Services => _serviceRepository ??= new Repository<Service>(_context);

        /// <inheritdoc/>
        public IRepository<ServiceType> ServiceTypes => _serviceTypeRepository ??= new Repository<ServiceType>(_context);

        /// <inheritdoc/>
        public IRepository<BookingService> BookingServices => _bookingServiceRepository ??= new Repository<BookingService>(_context);

        /// <inheritdoc/>
        public IRepository<User> Users => _userRepository ??= new Repository<User>(_context);

        /// <inheritdoc/>
        public IRepository<Bill> Bills => _billRepository ??= new Repository<Bill>(_context);

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <inheritdoc/>
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc/>
        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Disposes the context and transaction
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the context and transaction
        /// </summary>
        /// <param name="disposing">Whether to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
