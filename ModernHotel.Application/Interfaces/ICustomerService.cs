using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Customer service
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>Collection of customer DTOs</returns>
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();

        /// <summary>
        /// Gets a customer by ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Customer DTO if found, otherwise null</returns>
        Task<CustomerDto> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Gets customers by email
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>Collection of customer DTOs with the specified email</returns>
        Task<IEnumerable<CustomerDto>> GetCustomersByEmailAsync(string email);

        /// <summary>
        /// Gets customers by name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Collection of customer DTOs with names containing the search term</returns>
        Task<IEnumerable<CustomerDto>> GetCustomersByNameAsync(string name);

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="createCustomerDto">Data for creating the customer</param>
        /// <returns>Created customer DTO</returns>
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="updateCustomerDto">Data for updating the customer</param>
        /// <returns>Updated customer DTO if successful, otherwise null</returns>
        Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteCustomerAsync(int id);

        /// <summary>
        /// Checks if a customer exists
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>True if the customer exists, otherwise false</returns>
        Task<bool> CustomerExistsAsync(int id);

        /// <summary>
        /// Checks if an email is already in use
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="excludeCustomerId">Customer ID to exclude from the check (for updates)</param>
        /// <returns>True if the email is already in use, otherwise false</returns>
        Task<bool> EmailExistsAsync(string email, int? excludeCustomerId = null);

        /// <summary>
        /// Gets customers with bookings
        /// </summary>
        /// <returns>Collection of customer DTOs with booking information</returns>
        Task<IEnumerable<CustomerDto>> GetCustomersWithBookingsAsync();
    }
}
