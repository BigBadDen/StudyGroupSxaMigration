using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    public class Sitecore8BrokenMediaLinkException : LinkException
    {
        public Sitecore8BrokenMediaLinkException(string message) : base(message)
        {
        }

        public Sitecore8BrokenMediaLinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Sitecore8BrokenMediaLinkException()
        {
        }

        public Sitecore8BrokenMediaLinkException(string message, string paramName) : base(message, paramName)
        {
        }

        public Sitecore8BrokenMediaLinkException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
