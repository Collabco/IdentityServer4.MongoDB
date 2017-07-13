using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdentityServer4.MongoDB;
using System.Threading.Tasks;
using System.Collections.Generic;
using IdentityServer4.MongoDB.Models;
using IdentityServer4.MongoDB.Stores;
using System.Linq;

namespace Integration.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestCreate()
        {
            var op = new ConfigurationDBOption {  ConnectionString = "mongodb://admin:7j3Z5w5rdf2MGVyG@myday-dev-shard-00-00-iqy12.mongodb.net:27017,myday-dev-shard-00-01-iqy12.mongodb.net:27017,myday-dev-shard-00-02-iqy12.mongodb.net:27017/?ssl=true&replicaSet=myday-dev-shard-0&authSource=admin", Database = "IS4"};
            op.ApiResource.CollectionName = "Configuration";
            op.Client.CollectionName = "Configuration";
            op.IdentityResource.CollectionName = "Configuration";
            var ops = Microsoft.Extensions.Options.Options.Create(op);          
            var context = new ConfigurationMongoDbContext(ops);

            await context.Client.InsertOneAsync(Mapper.ToEntity(new IdentityServer4.Models.Client
            {
                ClientId = "Client1",
                ClientName = "Client 1",
                AllowedGrantTypes = new List<string> { "client_credentials" }
            }));
            await context.Client.InsertOneAsync(Mapper.ToEntity(new IdentityServer4.Models.Client
            {
              ClientId = "Client2",
              ClientName = "Client 2",
              Enabled = true,
              AllowedGrantTypes = new List<string> { "authorization_code" }
            }));
            await context.ApiResource.InsertOneAsync(Mapper.ToEntity(new IdentityServer4.Models.ApiResource
            {
                Name = "123",
                Enabled = true,
                DisplayName = "123",
                Scopes = new List<IdentityServer4.Models.Scope> { new IdentityServer4.Models.Scope {  Name = "Stuff" } }
            }));
            var clientStore = new ClientStore(context);
            var client1 = await clientStore.FindClientByIdAsync("Client1");
            Assert.IsNotNull(client1?.ClientId);
            Assert.AreEqual("Client1", client1.ClientId);
            var client2 = await clientStore.FindClientByIdAsync("Client2");
            Assert.IsNotNull(client2?.ClientId);
            Assert.AreEqual("Client2", client2.ClientId);
            var resStore = new ResourceStore(context);
            var resources = await resStore.GetAllResources();
            Assert.AreEqual(1, resources.ApiResources.Count);
            Assert.AreEqual(0, resources.IdentityResources.Count);
            Assert.AreEqual("123", resources.ApiResources.FirstOrDefault().Name);
        }
    }
}
 