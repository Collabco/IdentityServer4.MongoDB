using MongoDB.Bson;
using System;

namespace  IdentityServer4.MongoDB.Models
{
    public class PersistedGrant
    {
        public ObjectId id { get; set; }
        public string key { get; set; }
        public string type { get; set; }
        public string subjectId { get; set; }
        public string clientId { get; set; }
        public DateTime creationTime { get; set; }
        public DateTime? expiration { get; set; }
        public string data { get; set; }
    }
}