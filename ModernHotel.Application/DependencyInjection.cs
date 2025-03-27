using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ModernHotel.Application.Interfaces;
using ModernHotel.Application.Services;

namespace ModernHotel.Application
{
    /// <summary>
    /// Extension methods for setting up application services in an IServiceCollection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds application services to the specified IServiceCollection
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to</param>
        /// <returns>The same service collection so that multiple calls can be chained</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register application services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IBookingServiceService, BookingServiceService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IReportService, ReportService>();

            return services;
        }
    }
}
