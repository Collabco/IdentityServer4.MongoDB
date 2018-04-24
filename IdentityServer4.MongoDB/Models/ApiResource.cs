using global::MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer4.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class ApiResource : ConfigObject
    {
        public ApiResource()
        {
        }

        public ApiResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            Name = name;
            DisplayName = displayName;
            UserClaims = claimTypes.ToList();
        }

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; } = true;

        [BsonId]
        public string Name { get; set; }
        public List<ApiScope> Scopes { get; set; }
        public List<ApiSecret> Secrets { get; set; }
        public List<string> UserClaims { get; set; }
    }
}