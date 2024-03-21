using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    /// <summary>
    /// Failure to update an item in Sitecore 9
    /// </summary>
    public class FailedUpdateException : Exception
    {
        public FailedUpdateException(string message) : base(message)
        {
        }

        public FailedUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FailedUpdateException()
        {
        }
    }
}
