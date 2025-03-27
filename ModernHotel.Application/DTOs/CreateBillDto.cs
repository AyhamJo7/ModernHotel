using System;
using System.ComponentModel.DataAnnotations;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating a new Bill
    /// </summary>
    public class CreateBillDto
    {
        /// <summary>
        /// ID of the booking this bill is for
        /// </summary>
        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingId { get; set; }

        /// <summary>
        /// ID of the user who created the bill
        /// </summary>
        [Required(ErrorMessage = "Issuer ID is required")]
        public int IssuedById { get; set; }

        /// <summary>
        /// Due date for payment
        /// </summary>
        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Subtotal amount (before tax and discounts)
        /// </summary>
        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0.01, 1000000, ErrorMessage = "Subtotal must be greater than 0")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Tax amount
        /// </summary>
        [Required(ErrorMessage = "Tax amount is required")]
        [Range(0, 1000000, ErrorMessage = "Tax amount must be between 0 and 1,000,000")]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Discount amount
        /// </summary>
        [Required(ErrorMessage = "Discount amount is required")]
        [Range(0, 1000000, ErrorMessage = "Discount amount must be between 0 and 1,000,000")]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Amount already paid
        /// </summary>
        [Required(ErrorMessage = "Paid amount is required")]
        [Range(0, 1000000, ErrorMessage = "Paid amount must be between 0 and 1,000,000")]
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Status of the bill
        /// </summary>
        [Required(ErrorMessage = "Bill status is required")]
        public BillStatus Status { get; set; }

        /// <summary>
        /// Payment method used
        /// </summary>
        public PaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// Notes or comments about the bill
        /// </summary>
        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string Notes { get; set; }
    }
}
