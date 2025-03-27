using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Service service
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Gets all services
        /// </summary>
        /// <returns>Collection of service DTOs</returns>
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();

        /// <summary>
        /// Gets a service by ID
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>Service DTO if found, otherwise null</returns>
        Task<ServiceDto> GetServiceByIdAsync(int id);

        /// <summary>
        /// Gets services by service type
        /// </summary>
        /// <param name="serviceTypeId">Service type ID</param>
        /// <returns>Collection of service DTOs with the specified service type</returns>
        Task<IEnumerable<ServiceDto>> GetServicesByServiceTypeAsync(int serviceTypeId);

        /// <summary>
        /// Gets available services
        /// </summary>
        /// <returns>Collection of available service DTOs</returns>
        Task<IEnumerable<ServiceDto>> GetAvailableServicesAsync();

        /// <summary>
        /// Creates a new service
        /// </summary>
        /// <param name="createServiceDto">Data for creating the service</param>
        /// <returns>Created service DTO</returns>
        Task<ServiceDto> CreateServiceAsync(CreateServiceDto createServiceDto);

        /// <summary>
        /// Updates an existing service
        /// </summary>
        /// <param name="updateServiceDto">Data for updating the service</param>
        /// <returns>Updated service DTO if successful, otherwise null</returns>
        Task<ServiceDto> UpdateServiceAsync(UpdateServiceDto updateServiceDto);

        /// <summary>
        /// Updates the availability of a service
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <param name="isAvailable">Availability status</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateServiceAvailabilityAsync(int id, bool isAvailable);

        /// <summary>
        /// Deletes a service
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteServiceAsync(int id);

        /// <summary>
        /// Checks if a service exists
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>True if the service exists, otherwise false</returns>
        Task<bool> ServiceExistsAsync(int id);

        /// <summary>
        /// Gets services by name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Collection of service DTOs with names containing the search term</returns>
        Task<IEnumerable<ServiceDto>> GetServicesByNameAsync(string name);

        /// <summary>
        /// Gets services by price range
        /// </summary>
        /// <param name="minPrice">Minimum price</param>
        /// <param name="maxPrice">Maximum price</param>
        /// <returns>Collection of service DTOs within the specified price range</returns>
        Task<IEnumerable<ServiceDto>> GetServicesByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}
