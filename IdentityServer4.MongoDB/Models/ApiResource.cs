using global::MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer4.MongoDB.Models
{
    public class ApiResource : ConfigObject
    {
        public ApiResource()
        {
        }

        public ApiResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            this.name = name;
            this.displayName = displayName;
            userClaims = claimTypes.ToList();
        }

        public string description { get; set; }
        public string displayName { get; set; }
        public bool enabled { get; set; } = true;

        [BsonId]
        public string name { get; set; }
        public List<ApiScope> scopes { get; set; }
        public List<ApiSecret> secrets { get; set; }
        public List<string> userClaims { get; set; }
    }
}