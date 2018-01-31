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
            this.name = name;
            this.displayName = displayName;
            userClaims = claimTypes.ToList();
        }

        public string description { get; set; }
        public string displayName { get; set; }
        public bool emphasize { get; set; }
        public bool enabled { get; set; } = true;
        [BsonId]
        public string name { get; set; }
        public bool required { get; set; }
        public bool showInDiscoveryDocument { get; set; } = true;
        public List<string> userClaims { get; set; }
    }
}