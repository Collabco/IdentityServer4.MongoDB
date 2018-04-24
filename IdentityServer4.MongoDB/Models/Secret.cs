using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static IdentityServer4.IdentityServerConstants;

namespace  IdentityServer4.MongoDB.Models
{
    public abstract class Secret
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }

        [BsonElement("expiration")]
        public DateTime? Expiration { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = SecretTypes.SharedSecret;
    }
}