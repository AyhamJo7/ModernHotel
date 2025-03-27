using System;
using System.Collections.Generic;
using ModernHotel.Core.Enums;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a bill for a booking
    /// </summary>
    public class Bill : BaseEntity
    {
        /// <summary>
        /// Unique bill number
        /// </summary>
        public string BillNumber { get; set; }

        /// <summary>
        /// ID of the booking this bill is for
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Navigation property for the booking
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// ID of the user who created the bill
        /// </summary>
        public int IssuedById { get; set; }

        /// <summary>
        /// Navigation property for the user who created the bill
        /// </summary>
        public User IssuedBy { get; set; }

        /// <summary>
        /// Date and time when the bill was issued
        /// </summary>
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

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
        public decimal TotalAmount => Subtotal + TaxAmount - DiscountAmount;

        /// <summary>
        /// Amount already paid
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Status of the bill
        /// </summary>
        public BillStatus Status { get; set; }

        /// <summary>
        /// Payment method used
        /// </summary>
        public PaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// Notes or comments about the bill
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets the remaining balance to be paid
        /// </summary>
        public decimal RemainingBalance => TotalAmount - PaidAmount;

        /// <summary>
        /// Indicates if the bill is fully paid
        /// </summary>
        public bool IsPaid => PaidAmount >= TotalAmount;
    }
}
