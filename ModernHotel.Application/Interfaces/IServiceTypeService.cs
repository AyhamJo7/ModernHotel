using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for ServiceType service
    /// </summary>
    public interface IServiceTypeService
    {
        /// <summary>
        /// Gets all service types
        /// </summary>
        /// <returns>Collection of service type DTOs</returns>
        Task<IEnumerable<ServiceTypeDto>> GetAllServiceTypesAsync();

        /// <summary>
        /// Gets a service type by ID
        /// </summary>
        /// <param name="id">Service type ID</param>
        /// <returns>Service type DTO if found, otherwise null</returns>
        Task<ServiceTypeDto> GetServiceTypeByIdAsync(int id);

        /// <summary>
        /// Creates a new service type
        /// </summary>
        /// <param name="createServiceTypeDto">Data for creating the service type</param>
        /// <returns>Created service type DTO</returns>
        Task<ServiceTypeDto> CreateServiceTypeAsync(CreateServiceTypeDto createServiceTypeDto);

        /// <summary>
        /// Updates an existing service type
        /// </summary>
        /// <param name="updateServiceTypeDto">Data for updating the service type</param>
        /// <returns>Updated service type DTO if successful, otherwise null</returns>
        Task<ServiceTypeDto> UpdateServiceTypeAsync(UpdateServiceTypeDto updateServiceTypeDto);

        /// <summary>
        /// Deletes a service type
        /// </summary>
        /// <param name="id">Service type ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteServiceTypeAsync(int id);

        /// <summary>
        /// Checks if a service type exists
        /// </summary>
        /// <param name="id">Service type ID</param>
        /// <returns>True if the service type exists, otherwise false</returns>
        Task<bool> ServiceTypeExistsAsync(int id);

        /// <summary>
        /// Gets service types with service count
        /// </summary>
        /// <returns>Collection of service type DTOs with service count</returns>
        Task<IEnumerable<ServiceTypeDto>> GetServiceTypesWithServiceCountAsync();

        /// <summary>
        /// Gets service types by name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Collection of service type DTOs with names containing the search term</returns>
        Task<IEnumerable<ServiceTypeDto>> GetServiceTypesByNameAsync(string name);
    }
}
