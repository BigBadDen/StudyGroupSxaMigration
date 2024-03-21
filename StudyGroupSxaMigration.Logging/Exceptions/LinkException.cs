using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.Logging.Exceptions
{
    /// <summary>
    /// Sitecore 8 Link target does not exist, or the equivalent item in Sitecore 9 does not exist
    /// </summary>
    public class LinkException : ArgumentException
    {
        //************** in progresss..... **************
        public virtual string Sitecore8ItemPath { get; }
        public virtual string Sitecore8ItemId { get; }
        public virtual string Sitecore8LinkTargetItemPath { get; }
        public virtual string Sitecore8LinkTargetItemId { get; }
        public virtual string Sitecore9ItemPath { get; }
        public virtual string Sitecore9ItemId { get; }
        public virtual string Sitecore9LinkTargetItemPath { get; }
        public virtual string Sitecore9LinkTargetItemId { get; }
        //******************************************

        public LinkException(string message, string linkId) : base(message, linkId)
        {
        }

        public LinkException()
        {
        }

        public LinkException(string message) : base(message)
        {
        }

        public LinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public LinkException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
