using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernHotel.Application;
using ModernHotel.Infrastructure;
using ModernHotel.Presentation.Views;
using Serilog;
using System.Globalization;

namespace ModernHotel.Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set up application configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Set up Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting application");

                // Set up host
                var host = CreateHostBuilder(configuration).Build();

                // Configure Windows Forms
                ApplicationConfiguration.Initialize();
                
                // Set culture info for the application
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

                // Run the application
                using (var serviceScope = host.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    
                    try
                    {
                        // Get the login form from the service provider
                        var loginForm = services.GetRequiredService<fLogin>();
                        Application.Run(loginForm);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "Application terminated unexpectedly");
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start");
                MessageBox.Show($"Application failed to start: {ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The host builder.</returns>
        static IHostBuilder CreateHostBuilder(IConfiguration configuration)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Add application services
                    services.AddApplication();

                    // Add infrastructure services
                    services.AddInfrastructure(configuration);

                    // Add presentation services
                    services.AddPresentationServices();

                    // Register forms
                    RegisterForms(services);
                })
                .UseSerilog();
        }

        /// <summary>
        /// Registers all forms with the service provider.
        /// </summary>
        /// <param name="services">The service collection.</param>
        private static void RegisterForms(IServiceCollection services)
        {
            // Register forms with appropriate lifetime
            services.AddTransient<fLogin>();
            services.AddTransient<fManagement>();
            services.AddTransient<fRoom>();
            services.AddTransient<fRoomType>();
            services.AddTransient<fCustomer>();
            services.AddTransient<fBookRoom>();
            services.AddTransient<fReceiveRoom>();
            services.AddTransient<fService>();
            services.AddTransient<fServiceType>();
            services.AddTransient<fBill>();
            services.AddTransient<fStaff>();
            services.AddTransient<fReport>();
            services.AddTransient<fProfile>();
            services.AddTransient<fAbout>();
        }
    }

    /// <summary>
    /// Extension methods for setting up presentation services
    /// </summary>
    public static class PresentationServiceExtensions
    {
        /// <summary>
        /// Adds presentation services to the specified IServiceCollection
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to</param>
        /// <returns>The same service collection so that multiple calls can be chained</returns>
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // Add presentation-specific services here
            
            return services;
        }
    }
}
