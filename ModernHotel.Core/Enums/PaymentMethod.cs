namespace ModernHotel.Core.Enums
{
    /// <summary>
    /// Enum representing the payment method used for a bill
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Payment by cash
        /// </summary>
        Cash = 1,
        
        /// <summary>
        /// Payment by credit card
        /// </summary>
        CreditCard = 2,
        
        /// <summary>
        /// Payment by debit card
        /// </summary>
        DebitCard = 3,
        
        /// <summary>
        /// Payment by bank transfer
        /// </summary>
        BankTransfer = 4,
        
        /// <summary>
        /// Payment by check
        /// </summary>
        Check = 5,
        
        /// <summary>
        /// Payment by mobile payment (e.g., Apple Pay, Google Pay)
        /// </summary>
        MobilePayment = 6,
        
        /// <summary>
        /// Payment by online payment service (e.g., PayPal)
        /// </summary>
        OnlinePayment = 7
    }
}
