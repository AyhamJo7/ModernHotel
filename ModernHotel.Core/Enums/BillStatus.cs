namespace ModernHotel.Core.Enums
{
    /// <summary>
    /// Enum representing the status of a bill
    /// </summary>
    public enum BillStatus
    {
        /// <summary>
        /// Bill has been created but not yet sent to the customer
        /// </summary>
        Draft = 1,
        
        /// <summary>
        /// Bill has been sent to the customer
        /// </summary>
        Sent = 2,
        
        /// <summary>
        /// Bill has been partially paid
        /// </summary>
        PartiallyPaid = 3,
        
        /// <summary>
        /// Bill has been fully paid
        /// </summary>
        Paid = 4,
        
        /// <summary>
        /// Bill is overdue
        /// </summary>
        Overdue = 5,
        
        /// <summary>
        /// Bill has been cancelled
        /// </summary>
        Cancelled = 6,
        
        /// <summary>
        /// Bill has been refunded
        /// </summary>
        Refunded = 7
    }
}
