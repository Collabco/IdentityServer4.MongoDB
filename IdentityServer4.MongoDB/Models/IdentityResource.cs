using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer4.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class IdentityResource : ConfigObject
    {
        public IdentityResource()
        {
        }

        public IdentityResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            Name = name;
            DisplayName = displayName;
            UserClaims = claimTypes.ToList();
        }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("displayName")]
        public string DisplayName { get; set; }

        [BsonElement("emphasize")]
        public bool Emphasize { get; set; }

        [BsonElement("enabled")]
        public bool Enabled { get; set; } = true;

        [BsonId]
        public string Name { get; set; }

        [BsonElement("required")]
        public bool Required { get; set; }

        [BsonElement("showInDiscoveryDocument")]
        public bool ShowInDiscoveryDocument { get; set; } = true;

        [BsonElement("userClaims")]
        public List<string> UserClaims { get; set; }
    }
}