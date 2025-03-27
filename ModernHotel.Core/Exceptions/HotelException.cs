using System;

namespace ModernHotel.Core.Exceptions
{
    /// <summary>
    /// Base exception class for hotel-related exceptions
    /// </summary>
    public class HotelException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelException"/> class
        /// </summary>
        public HotelException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public HotelException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public HotelException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown when an entity is not found
    /// </summary>
    public class EntityNotFoundException : HotelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
        /// </summary>
        public EntityNotFoundException() : base("The requested entity was not found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public EntityNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified entity type and ID
        /// </summary>
        /// <param name="entityType">The type of entity that was not found</param>
        /// <param name="id">The ID of the entity that was not found</param>
        public EntityNotFoundException(string entityType, object id)
            : base($"{entityType} with ID {id} was not found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown when a business rule is violated
    /// </summary>
    public class BusinessRuleException : HotelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRuleException"/> class
        /// </summary>
        public BusinessRuleException() : base("A business rule was violated.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRuleException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public BusinessRuleException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRuleException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public BusinessRuleException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown when authentication fails
    /// </summary>
    public class AuthenticationException : HotelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException"/> class
        /// </summary>
        public AuthenticationException() : base("Authentication failed.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public AuthenticationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AuthenticationException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown when authorization fails
    /// </summary>
    public class AuthorizationException : HotelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationException"/> class
        /// </summary>
        public AuthorizationException() : base("You are not authorized to perform this action.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public AuthorizationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown when validation fails
    /// </summary>
    public class ValidationException : HotelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class
        /// </summary>
        public ValidationException() : base("Validation failed.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public ValidationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
