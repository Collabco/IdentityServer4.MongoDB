using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.Models
{
    public class ApiScope
    {
        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("displayName")]
        public string DisplayName { get; set; }

        [BsonElement("emphasize")]
        public bool Emphasize { get; set; }

        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("required")]
        public bool Required { get; set; }

        [BsonElement("showInDiscoveryDocument")]
        public bool ShowInDiscoveryDocument { get; set; } = true;

        [BsonElement("userClaims")]
        public List<string> UserClaims { get; set; }
    }
}