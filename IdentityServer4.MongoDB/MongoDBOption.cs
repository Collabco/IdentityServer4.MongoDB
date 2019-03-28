using MongoDB.Driver;

namespace IdentityServer4.MongoDB
{
    public class ConfigurationDBOption : MongoDBOptionBase
    {
        public Option ApiResource { get; set; } = new Option
        {
            CollectionName = "Configuration"
        };

        public Option Client { get; set; } = new Option
        {
            CollectionName = "Configuration"
        };

        public Option IdentityResource { get; set; } = new Option
        {
            CollectionName = "Configuration"
        };
    }

    public abstract class MongoDBOptionBase
    {
        /// <summary>
        /// Client settings for connecting to mongodb
        /// </summary>
        /// <remarks>Setting this overrides use of the connection string</remarks>
        public MongoClientSettings MongoClientSettings { get; set; }

        /// <summary>
        /// Connection string for connecting to mongodb
        /// </summary>       
        public string ConnectionString { get; set; }

        public string Database { get; set; }
    }

    public class OperationMongoDBOption : MongoDBOptionBase
    {
        public Option PersistedGrant { get; set; } = new Option
        {
            CollectionName = "PersistedGrant",
        };
    }

    public class Option
    {
        public string CollectionName { get; set; }

        public bool ManageIndicies { get; set; } = true;
    }
}