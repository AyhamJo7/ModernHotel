using System;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Bill
    /// </summary>
    public class BillDto
    {
        /// <summary>
        /// ID of the bill
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique bill number
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// ID of the booking this bill is for
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Reference number of the booking
        /// </summary>
        public string BookingReference { get; set; }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ID of the user who created the bill
        /// </summary>
        public int IssuedById { get; set; }

        /// <summary>
        /// Name of the user who created the bill
        /// </summary>
        public string IssuedByName { get; set; }

        /// <summary>
        /// Date and time when the bill was issued
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Date and time when the bill was paid
        /// </summary>
        public DateTime? PaidDate { get; set; }

        /// <summary>
        /// Due date for payment
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Subtotal amount (before tax and discounts)
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Tax amount
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Discount amount
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Total amount (Subtotal + TaxAmount - DiscountAmount)
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Amount already paid
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Status of the bill
        /// </summary>
        public BillStatus Status { get; set; }

        /// <summary>
        /// Status of the bill as a string
        /// </summary>
        public string StatusName => Status.ToString();

        /// <summary>
        /// Payment method used
        /// </summary>
        public PaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// Payment method used as a string
        /// </summary>
        public string PaymentMethodName => PaymentMethod?.ToString();

        /// <summary>
        /// Notes or comments about the bill
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Remaining balance to be paid
        /// </summary>
        public decimal RemainingBalance => TotalAmount - PaidAmount;

        /// <summary>
        /// Indicates if the bill is fully paid
        /// </summary>
        public bool IsPaid => PaidAmount >= TotalAmount;

        /// <summary>
        /// Indicates if the bill is overdue
        /// </summary>
        public bool IsOverdue => !IsPaid && DateTime.Now > DueDate;

        /// <summary>
        /// Date and time when the bill was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the bill was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
