using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    public class UpdateTargetNotFoundException : ArgumentException
    {
        public UpdateTargetNotFoundException(string message) : base(message)
        {
        }

        public UpdateTargetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UpdateTargetNotFoundException() : base()
        {
        }

        public UpdateTargetNotFoundException(string message, string paramName) : base(message, paramName)
        {
        }

        public UpdateTargetNotFoundException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
