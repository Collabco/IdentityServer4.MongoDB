using System;
using MongoDB.Bson;
using static IdentityServer4.IdentityServerConstants;

namespace  IdentityServer4.MongoDB.Models
{
    public abstract class Secret
    {
        public ObjectId id { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public DateTime? expiration { get; set; }
        public string type { get; set; } = SecretTypes.SharedSecret;
    }
}