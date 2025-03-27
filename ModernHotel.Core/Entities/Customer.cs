using System;
using System.Collections.Generic;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a customer of the hotel
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// First name of the customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the customer
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Postal/Zip code of the customer
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// ID card or passport number of the customer
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Date of birth of the customer
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Collection of bookings made by this customer
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// Gets the full name of the customer
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
    }
}
