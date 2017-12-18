using MongoDB.Bson;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.Models
{
    public class ApiScope
    {
        public string description { get; set; }
        public string displayName { get; set; }
        public bool emphasize { get; set; }
        public ObjectId id { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
        public bool showInDiscoveryDocument { get; set; } = true;
        public List<string> userClaims { get; set; }
    }
}