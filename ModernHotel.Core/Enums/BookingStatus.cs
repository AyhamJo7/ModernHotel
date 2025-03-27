namespace ModernHotel.Core.Enums
{
    /// <summary>
    /// Enum representing the status of a booking
    /// </summary>
    public enum BookingStatus
    {
        /// <summary>
        /// Booking is confirmed but customer has not checked in yet
        /// </summary>
        Confirmed = 1,
        
        /// <summary>
        /// Customer has checked in
        /// </summary>
        CheckedIn = 2,
        
        /// <summary>
        /// Customer has checked out
        /// </summary>
        CheckedOut = 3,
        
        /// <summary>
        /// Booking has been cancelled
        /// </summary>
        Cancelled = 4,
        
        /// <summary>
        /// Booking is on hold (e.g., awaiting payment)
        /// </summary>
        OnHold = 5,
        
        /// <summary>
        /// Customer did not show up
        /// </summary>
        NoShow = 6
    }
}
