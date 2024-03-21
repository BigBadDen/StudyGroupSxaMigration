using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    public class BrokenItemLinkSitecore9Exception : LinkException
    {
        public BrokenItemLinkSitecore9Exception(string message) : base(message)
        {
        }

        public BrokenItemLinkSitecore9Exception(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BrokenItemLinkSitecore9Exception()
        {
        }

        public BrokenItemLinkSitecore9Exception(string message, string paramName) : base(message, paramName)
        {
        }

        public BrokenItemLinkSitecore9Exception(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
