namespace ModernHotel.Core.Enums
{
    /// <summary>
    /// Enum representing the role of a user in the system
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Administrator with full access to all features
        /// </summary>
        Administrator = 1,
        
        /// <summary>
        /// Manager with access to most features except user management
        /// </summary>
        Manager = 2,
        
        /// <summary>
        /// Receptionist with access to customer and booking management
        /// </summary>
        Receptionist = 3,
        
        /// <summary>
        /// Staff with limited access to specific features
        /// </summary>
        Staff = 4
    }
}
