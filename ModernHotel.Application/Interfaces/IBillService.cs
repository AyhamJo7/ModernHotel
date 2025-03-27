using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Bill service
    /// </summary>
    public interface IBillService
    {
        /// <summary>
        /// Gets all bills
        /// </summary>
        /// <returns>Collection of bill DTOs</returns>
        Task<IEnumerable<BillDto>> GetAllBillsAsync();

        /// <summary>
        /// Gets a bill by ID
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <returns>Bill DTO if found, otherwise null</returns>
        Task<BillDto> GetBillByIdAsync(int id);

        /// <summary>
        /// Gets a bill by bill number
        /// </summary>
        /// <param name="billNumber">Bill number</param>
        /// <returns>Bill DTO if found, otherwise null</returns>
        Task<BillDto> GetBillByNumberAsync(string billNumber);

        /// <summary>
        /// Gets bills by booking ID
        /// </summary>
        /// <param name="bookingId">Booking ID</param>
        /// <returns>Collection of bill DTOs for the specified booking</returns>
        Task<IEnumerable<BillDto>> GetBillsByBookingIdAsync(int bookingId);

        /// <summary>
        /// Gets bills by customer ID
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Collection of bill DTOs for the specified customer</returns>
        Task<IEnumerable<BillDto>> GetBillsByCustomerIdAsync(int customerId);

        /// <summary>
        /// Gets bills by status
        /// </summary>
        /// <param name="status">Bill status</param>
        /// <returns>Collection of bill DTOs with the specified status</returns>
        Task<IEnumerable<BillDto>> GetBillsByStatusAsync(BillStatus status);

        /// <summary>
        /// Gets bills for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of bill DTOs within the specified date range</returns>
        Task<IEnumerable<BillDto>> GetBillsByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets unpaid bills
        /// </summary>
        /// <returns>Collection of unpaid bill DTOs</returns>
        Task<IEnumerable<BillDto>> GetUnpaidBillsAsync();

        /// <summary>
        /// Gets overdue bills
        /// </summary>
        /// <returns>Collection of overdue bill DTOs</returns>
        Task<IEnumerable<BillDto>> GetOverdueBillsAsync();

        /// <summary>
        /// Creates a new bill
        /// </summary>
        /// <param name="createBillDto">Data for creating the bill</param>
        /// <returns>Created bill DTO</returns>
        Task<BillDto> CreateBillAsync(CreateBillDto createBillDto);

        /// <summary>
        /// Creates a bill for a booking
        /// </summary>
        /// <param name="bookingId">Booking ID</param>
        /// <param name="issuedById">ID of the user who created the bill</param>
        /// <returns>Created bill DTO</returns>
        Task<BillDto> CreateBillForBookingAsync(int bookingId, int issuedById);

        /// <summary>
        /// Updates an existing bill
        /// </summary>
        /// <param name="updateBillDto">Data for updating the bill</param>
        /// <returns>Updated bill DTO if successful, otherwise null</returns>
        Task<BillDto> UpdateBillAsync(UpdateBillDto updateBillDto);

        /// <summary>
        /// Updates the status of a bill
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <param name="status">New bill status</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateBillStatusAsync(int id, BillStatus status);

        /// <summary>
        /// Records a payment for a bill
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <param name="amount">Payment amount</param>
        /// <param name="paymentMethod">Payment method</param>
        /// <returns>Updated bill DTO if successful, otherwise null</returns>
        Task<BillDto> RecordPaymentAsync(int id, decimal amount, PaymentMethod paymentMethod);

        /// <summary>
        /// Marks a bill as paid
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <param name="paymentMethod">Payment method</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> MarkAsPaidAsync(int id, PaymentMethod paymentMethod);

        /// <summary>
        /// Deletes a bill
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteBillAsync(int id);

        /// <summary>
        /// Checks if a bill exists
        /// </summary>
        /// <param name="id">Bill ID</param>
        /// <returns>True if the bill exists, otherwise false</returns>
        Task<bool> BillExistsAsync(int id);

        /// <summary>
        /// Generates a bill number
        /// </summary>
        /// <returns>Generated bill number</returns>
        Task<string> GenerateBillNumberAsync();

        /// <summary>
        /// Calculates the total amount for a bill
        /// </summary>
        /// <param name="subtotal">Subtotal amount</param>
        /// <param name="taxAmount">Tax amount</param>
        /// <param name="discountAmount">Discount amount</param>
        /// <returns>Total amount</returns>
        decimal CalculateTotalAmount(decimal subtotal, decimal taxAmount, decimal discountAmount);
    }
}
