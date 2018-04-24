using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace  IdentityServer4.MongoDB.Models
{
    public class PersistedGrant
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("subjectId")]
        public string SubjectId { get; set; }

        [BsonElement("clientId")]
        public string ClientId { get; set; }

        [BsonElement("creationTime")]
        public DateTime CreationTime { get; set; }

        [BsonElement("expiration")]
        public DateTime? Expiration { get; set; }

        [BsonElement("data")]
        public string Data { get; set; }
    }
}