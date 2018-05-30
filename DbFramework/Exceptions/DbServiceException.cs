using System;
using System.Diagnostics.CodeAnalysis;

namespace DbFramework.Exceptions
{
    public class DbServiceException : Exception
    {
		[ExcludeFromCodeCoverage]
        public DbServiceException()
        {
        }

	    [ExcludeFromCodeCoverage]
		public DbServiceException(string message) : base(message)
        {
        }

	    [ExcludeFromCodeCoverage]
		public DbServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
