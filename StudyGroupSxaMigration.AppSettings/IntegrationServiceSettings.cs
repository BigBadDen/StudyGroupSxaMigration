using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.AppSettings
{
    public class IntegrationServiceSettings
    {
        public bool ValidationService { get; set; }
        public bool SharedItemIntegrationService { get; set; }
        public bool WeBlogIntegrationService { get; set; }
        public bool NewsIntegrationService { get; set; }
        public bool PageDataSourceIntegrationServiceUpdatePageItems { get; set; }
        public bool PageDataSourceIntegrationServiceCreateDataItems { get; set; }
    }
}
