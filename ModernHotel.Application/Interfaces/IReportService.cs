using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Report service
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Gets a report of bookings for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of booking DTOs within the specified date range</returns>
        Task<IEnumerable<BookingDto>> GetBookingReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of revenue for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Revenue report data</returns>
        Task<RevenueReportDto> GetRevenueReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of occupancy for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Occupancy report data</returns>
        Task<OccupancyReportDto> GetOccupancyReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of services used for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Service usage report data</returns>
        Task<ServiceUsageReportDto> GetServiceUsageReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of customer statistics
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Customer statistics report data</returns>
        Task<CustomerStatisticsReportDto> GetCustomerStatisticsReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of room type popularity
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Room type popularity report data</returns>
        Task<RoomTypePopularityReportDto> GetRoomTypePopularityReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of daily revenue
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Daily revenue report data</returns>
        Task<DailyRevenueReportDto> GetDailyRevenueReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets a report of monthly revenue
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>Monthly revenue report data</returns>
        Task<MonthlyRevenueReportDto> GetMonthlyRevenueReportAsync(int year);

        /// <summary>
        /// Gets a report of yearly revenue
        /// </summary>
        /// <param name="startYear">Start year</param>
        /// <param name="endYear">End year</param>
        /// <returns>Yearly revenue report data</returns>
        Task<YearlyRevenueReportDto> GetYearlyRevenueReportAsync(int startYear, int endYear);

        /// <summary>
        /// Exports a report to Excel
        /// </summary>
        /// <param name="reportType">Type of report</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Path to the exported Excel file</returns>
        Task<string> ExportReportToExcelAsync(string reportType, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Exports a report to PDF
        /// </summary>
        /// <param name="reportType">Type of report</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Path to the exported PDF file</returns>
        Task<string> ExportReportToPdfAsync(string reportType, DateTime startDate, DateTime endDate);
    }

    /// <summary>
    /// Data Transfer Object for Revenue Report
    /// </summary>
    public class RevenueReportDto
    {
        /// <summary>
        /// Total revenue
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Revenue from room bookings
        /// </summary>
        public decimal RoomRevenue { get; set; }

        /// <summary>
        /// Revenue from services
        /// </summary>
        public decimal ServiceRevenue { get; set; }

        /// <summary>
        /// Total tax collected
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total discounts given
        /// </summary>
        public decimal TotalDiscounts { get; set; }

        /// <summary>
        /// Net revenue (TotalRevenue - TotalTax)
        /// </summary>
        public decimal NetRevenue => TotalRevenue - TotalTax;

        /// <summary>
        /// Average revenue per booking
        /// </summary>
        public decimal AverageRevenuePerBooking { get; set; }

        /// <summary>
        /// Average revenue per day
        /// </summary>
        public decimal AverageRevenuePerDay { get; set; }

        /// <summary>
        /// Revenue by room type
        /// </summary>
        public Dictionary<string, decimal> RevenueByRoomType { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Revenue by service type
        /// </summary>
        public Dictionary<string, decimal> RevenueByServiceType { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Number of days in the report period
        /// </summary>
        public int NumberOfDays => (EndDate - StartDate).Days + 1;
    }

    /// <summary>
    /// Data Transfer Object for Occupancy Report
    /// </summary>
    public class OccupancyReportDto
    {
        /// <summary>
        /// Total number of rooms
        /// </summary>
        public int TotalRooms { get; set; }

        /// <summary>
        /// Total number of room-nights available
        /// </summary>
        public int TotalRoomNightsAvailable { get; set; }

        /// <summary>
        /// Total number of room-nights occupied
        /// </summary>
        public int TotalRoomNightsOccupied { get; set; }

        /// <summary>
        /// Overall occupancy rate
        /// </summary>
        public decimal OverallOccupancyRate => TotalRoomNightsAvailable > 0 
            ? (decimal)TotalRoomNightsOccupied / TotalRoomNightsAvailable * 100 
            : 0;

        /// <summary>
        /// Average daily occupancy rate
        /// </summary>
        public decimal AverageDailyOccupancyRate { get; set; }

        /// <summary>
        /// Occupancy rate by room type
        /// </summary>
        public Dictionary<string, decimal> OccupancyRateByRoomType { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Occupancy rate by day
        /// </summary>
        public Dictionary<DateTime, decimal> OccupancyRateByDay { get; set; } = new Dictionary<DateTime, decimal>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Number of days in the report period
        /// </summary>
        public int NumberOfDays => (EndDate - StartDate).Days + 1;
    }

    /// <summary>
    /// Data Transfer Object for Service Usage Report
    /// </summary>
    public class ServiceUsageReportDto
    {
        /// <summary>
        /// Total number of services used
        /// </summary>
        public int TotalServicesUsed { get; set; }

        /// <summary>
        /// Total revenue from services
        /// </summary>
        public decimal TotalServiceRevenue { get; set; }

        /// <summary>
        /// Average revenue per service
        /// </summary>
        public decimal AverageRevenuePerService => TotalServicesUsed > 0 
            ? TotalServiceRevenue / TotalServicesUsed 
            : 0;

        /// <summary>
        /// Service usage by service type
        /// </summary>
        public Dictionary<string, int> ServiceUsageByType { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Service revenue by service type
        /// </summary>
        public Dictionary<string, decimal> ServiceRevenueByType { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Most popular services
        /// </summary>
        public List<ServiceUsageItemDto> MostPopularServices { get; set; } = new List<ServiceUsageItemDto>();

        /// <summary>
        /// Highest revenue services
        /// </summary>
        public List<ServiceUsageItemDto> HighestRevenueServices { get; set; } = new List<ServiceUsageItemDto>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Service Usage Item
    /// </summary>
    public class ServiceUsageItemDto
    {
        /// <summary>
        /// Service name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// Number of times the service was used
        /// </summary>
        public int UsageCount { get; set; }

        /// <summary>
        /// Total revenue from the service
        /// </summary>
        public decimal TotalRevenue { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Customer Statistics Report
    /// </summary>
    public class CustomerStatisticsReportDto
    {
        /// <summary>
        /// Total number of customers
        /// </summary>
        public int TotalCustomers { get; set; }

        /// <summary>
        /// Number of new customers
        /// </summary>
        public int NewCustomers { get; set; }

        /// <summary>
        /// Number of returning customers
        /// </summary>
        public int ReturningCustomers { get; set; }

        /// <summary>
        /// Average number of bookings per customer
        /// </summary>
        public decimal AverageBookingsPerCustomer { get; set; }

        /// <summary>
        /// Average revenue per customer
        /// </summary>
        public decimal AverageRevenuePerCustomer { get; set; }

        /// <summary>
        /// Top customers by revenue
        /// </summary>
        public List<CustomerStatisticsItemDto> TopCustomersByRevenue { get; set; } = new List<CustomerStatisticsItemDto>();

        /// <summary>
        /// Top customers by number of bookings
        /// </summary>
        public List<CustomerStatisticsItemDto> TopCustomersByBookings { get; set; } = new List<CustomerStatisticsItemDto>();

        /// <summary>
        /// Customer distribution by country
        /// </summary>
        public Dictionary<string, int> CustomersByCountry { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Customer Statistics Item
    /// </summary>
    public class CustomerStatisticsItemDto
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Number of bookings
        /// </summary>
        public int BookingCount { get; set; }

        /// <summary>
        /// Total revenue
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// First booking date
        /// </summary>
        public DateTime FirstBookingDate { get; set; }

        /// <summary>
        /// Last booking date
        /// </summary>
        public DateTime LastBookingDate { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Room Type Popularity Report
    /// </summary>
    public class RoomTypePopularityReportDto
    {
        /// <summary>
        /// Room type statistics
        /// </summary>
        public List<RoomTypeStatisticsDto> RoomTypeStatistics { get; set; } = new List<RoomTypeStatisticsDto>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Room Type Statistics
    /// </summary>
    public class RoomTypeStatisticsDto
    {
        /// <summary>
        /// Room type ID
        /// </summary>
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Room type name
        /// </summary>
        public string RoomTypeName { get; set; }

        /// <summary>
        /// Number of rooms of this type
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// Number of bookings for this room type
        /// </summary>
        public int BookingCount { get; set; }

        /// <summary>
        /// Total revenue from this room type
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Occupancy rate for this room type
        /// </summary>
        public decimal OccupancyRate { get; set; }

        /// <summary>
        /// Average length of stay for this room type
        /// </summary>
        public decimal AverageLengthOfStay { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Daily Revenue Report
    /// </summary>
    public class DailyRevenueReportDto
    {
        /// <summary>
        /// Daily revenue data
        /// </summary>
        public Dictionary<DateTime, decimal> DailyRevenue { get; set; } = new Dictionary<DateTime, decimal>();

        /// <summary>
        /// Daily room revenue data
        /// </summary>
        public Dictionary<DateTime, decimal> DailyRoomRevenue { get; set; } = new Dictionary<DateTime, decimal>();

        /// <summary>
        /// Daily service revenue data
        /// </summary>
        public Dictionary<DateTime, decimal> DailyServiceRevenue { get; set; } = new Dictionary<DateTime, decimal>();

        /// <summary>
        /// Start date of the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the report
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Total revenue for the period
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Average daily revenue
        /// </summary>
        public decimal AverageDailyRevenue { get; set; }

        /// <summary>
        /// Highest daily revenue
        /// </summary>
        public decimal HighestDailyRevenue { get; set; }

        /// <summary>
        /// Date with highest revenue
        /// </summary>
        public DateTime HighestRevenueDate { get; set; }

        /// <summary>
        /// Lowest daily revenue
        /// </summary>
        public decimal LowestDailyRevenue { get; set; }

        /// <summary>
        /// Date with lowest revenue
        /// </summary>
        public DateTime LowestRevenueDate { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Monthly Revenue Report
    /// </summary>
    public class MonthlyRevenueReportDto
    {
        /// <summary>
        /// Year of the report
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Monthly revenue data
        /// </summary>
        public Dictionary<int, decimal> MonthlyRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Monthly room revenue data
        /// </summary>
        public Dictionary<int, decimal> MonthlyRoomRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Monthly service revenue data
        /// </summary>
        public Dictionary<int, decimal> MonthlyServiceRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Total revenue for the year
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Average monthly revenue
        /// </summary>
        public decimal AverageMonthlyRevenue { get; set; }

        /// <summary>
        /// Highest monthly revenue
        /// </summary>
        public decimal HighestMonthlyRevenue { get; set; }

        /// <summary>
        /// Month with highest revenue
        /// </summary>
        public int HighestRevenueMonth { get; set; }

        /// <summary>
        /// Lowest monthly revenue
        /// </summary>
        public decimal LowestMonthlyRevenue { get; set; }

        /// <summary>
        /// Month with lowest revenue
        /// </summary>
        public int LowestRevenueMonth { get; set; }
    }

    /// <summary>
    /// Data Transfer Object for Yearly Revenue Report
    /// </summary>
    public class YearlyRevenueReportDto
    {
        /// <summary>
        /// Yearly revenue data
        /// </summary>
        public Dictionary<int, decimal> YearlyRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Yearly room revenue data
        /// </summary>
        public Dictionary<int, decimal> YearlyRoomRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Yearly service revenue data
        /// </summary>
        public Dictionary<int, decimal> YearlyServiceRevenue { get; set; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Start year of the report
        /// </summary>
        public int StartYear { get; set; }

        /// <summary>
        /// End year of the report
        /// </summary>
        public int EndYear { get; set; }

        /// <summary>
        /// Total revenue for the period
        /// </summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Average yearly revenue
        /// </summary>
        public decimal AverageYearlyRevenue { get; set; }

        /// <summary>
        /// Highest yearly revenue
        /// </summary>
        public decimal HighestYearlyRevenue { get; set; }

        /// <summary>
        /// Year with highest revenue
        /// </summary>
        public int HighestRevenueYear { get; set; }

        /// <summary>
        /// Lowest yearly revenue
        /// </summary>
        public decimal LowestYearlyRevenue { get; set; }

        /// <summary>
        /// Year with lowest revenue
        /// </summary>
        public int LowestRevenueYear { get; set; }
    }
}
