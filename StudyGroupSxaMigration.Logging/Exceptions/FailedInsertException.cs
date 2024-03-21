using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    /// <summary>
    /// Failure to insert an item into Sitecore 9
    /// </summary>
    public class FailedInsertException : Exception
    {
        public FailedInsertException(string message) : base(message)
        {
        }

        public FailedInsertException()
        {
        }

        public FailedInsertException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
