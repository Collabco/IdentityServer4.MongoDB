using IdentityServer4.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB
{
    public interface IConfigurationMongoDbContext
    {
        IMongoCollection<ApiResource> ApiResource { get; }
        IMongoCollection<Client> Client { get; }
        IMongoCollection<IdentityResource> IdentityResource { get; }
    }

    public interface IOperationDbContext
    {
        IMongoCollection<PersistedGrant> PersistedGrant { get; }
    }

    public class ConfigurationMongoDbContext : IConfigurationMongoDbContext
    {
        public ConfigurationMongoDbContext(IOptions<ConfigurationDBOption> option)
        {
            var client = option.Value.MongoClientSettings != null ? new MongoClient(option.Value.MongoClientSettings) : new MongoClient(option.Value.ConnectionString);
            var database = client.GetDatabase(option.Value.Database);

            Client = database.GetCollection<ConfigObject>(option.Value.Client.CollectionName).OfType<Client>();
            ApiResource = database.GetCollection<ConfigObject>(option.Value.ApiResource.CollectionName).OfType<ApiResource>();
            IdentityResource = database.GetCollection<ConfigObject>(option.Value.IdentityResource.CollectionName).OfType<IdentityResource>();
        }

        public IMongoCollection<ApiResource> ApiResource { get; private set; }
        public IMongoCollection<Client> Client { get; private set; }
        public IMongoCollection<IdentityResource> IdentityResource { get; private set; }
    }

    public class OperationDbContext : IOperationDbContext
    {
        public OperationDbContext(IOptions<OperationMongoDBOption> option)
        {
            var client = option.Value.MongoClientSettings != null ? new MongoClient(option.Value.MongoClientSettings) : new MongoClient(option.Value.ConnectionString);
            var database = client.GetDatabase(option.Value.Database);

            PersistedGrant = database.GetCollection<PersistedGrant>(option.Value.PersistedGrant.CollectionName);
        }

        public IMongoCollection<PersistedGrant> PersistedGrant { get; private set; }
    }
}