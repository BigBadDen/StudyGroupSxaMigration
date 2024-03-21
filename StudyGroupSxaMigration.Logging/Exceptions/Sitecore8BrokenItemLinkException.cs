using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    public class Sitecore8BrokenItemLinkException : LinkException
    {
        public Sitecore8BrokenItemLinkException(string message) : base(message)
        {
        }

        public Sitecore8BrokenItemLinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Sitecore8BrokenItemLinkException()
        {
        }

        public Sitecore8BrokenItemLinkException(string message, string paramName) : base(message, paramName)
        {
        }

        public Sitecore8BrokenItemLinkException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
