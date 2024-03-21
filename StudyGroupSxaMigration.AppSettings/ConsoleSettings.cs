using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.AppSettings
{
    public class ConsoleSettings
    {
        public bool WriteDebugInfoToConsole { get; set; }
        public bool WriteTraceInfoToConsole { get; set; }
        public bool WriteItemAlreadyExistsWarningsToConsole { get; set; }
        public bool WriteSitecore8ItemRetrievalFailureToConsole { get; set; }
        public bool WriteSitecore9ItemRetrievalFailureToConsole { get; set; }
    }
}
