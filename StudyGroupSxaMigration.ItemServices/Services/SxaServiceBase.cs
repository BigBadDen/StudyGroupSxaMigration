using Microsoft.Extensions.Logging;
using StudyGroupSxaMigration.AppSettings;
using StudyGroupSxaMigration.ItemServices.LinkHelpers;
using StudyGroupSxaMigration.Logging;
using StudyGroupSxaMigration.Sitecore8;
using StudyGroupSxaMigration.Sitecore9;

namespace StudyGroupSxaMigration.ItemServices.Services
{
    public class SxaServiceBase
    {
        internal ISitecore9Client _sitecore9Client;
        internal ISitecore8Client _sitecore8Client;
        internal ILogger<ISxaService> _logger;
        internal MigrationLogger migrationLogger;
        internal RichTextFieldMigration _richTextFieldMigration;
        internal LinkFieldMigration _linkFieldMigration;
        internal ImageFieldMigration _imageFieldMigration;
        internal ApplicationSettings _applicationSettings;

        /// <summary>
        /// Initialise logger
        /// </summary>
        /// <param name="sitecore9Client"></param>
        /// <param name="sitecore9Website"></param>
        /// 

        public SxaServiceBase( ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings, ISitecore8Client sitecore8Client)
        {
            _sitecore8Client = sitecore8Client;
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings,  ISitecore8Client sitecore8Client, RichTextFieldMigration richTextFieldMigration)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _sitecore8Client = sitecore8Client;
            _richTextFieldMigration = richTextFieldMigration;
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings, ISitecore8Client sitecore8Client, RichTextFieldMigration richTextFieldMigration, ImageFieldMigration imageFieldMigration)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _sitecore8Client = sitecore8Client;
            _richTextFieldMigration = richTextFieldMigration;
            _imageFieldMigration = imageFieldMigration;
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings, ISitecore8Client sitecore8Client, RichTextFieldMigration richTextFieldMigration, ImageFieldMigration imageFieldMigration, LinkFieldMigration linkFieldMigration)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _sitecore8Client = sitecore8Client;
            _richTextFieldMigration = richTextFieldMigration;
            _imageFieldMigration = imageFieldMigration;
            _linkFieldMigration = linkFieldMigration;
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings, ISitecore8Client sitecore8Client, LinkFieldMigration linkFieldMigration)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _sitecore8Client = sitecore8Client;
            _linkFieldMigration = linkFieldMigration;
        }

        public SxaServiceBase(ISitecore9Client sitecore9Client, ILogger<ISxaService> logger, ApplicationSettings applicationSettings, ImageFieldMigration imageFieldMigration)
        {
            _sitecore9Client = sitecore9Client;
            _logger = logger;
            _applicationSettings = applicationSettings;
            migrationLogger = new MigrationLogger(applicationSettings, logger);
            _imageFieldMigration = imageFieldMigration;
        }
    }
}
