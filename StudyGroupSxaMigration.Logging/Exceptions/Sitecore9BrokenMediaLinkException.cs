using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    public class Sitecore9BrokenMediaLinkException : LinkException
    {
        public Sitecore9BrokenMediaLinkException(string message) : base(message)
        {
        }

        public Sitecore9BrokenMediaLinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Sitecore9BrokenMediaLinkException()
        {
        }

        public Sitecore9BrokenMediaLinkException(string message, string paramName) : base(message, paramName)
        {
        }

        public Sitecore9BrokenMediaLinkException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
