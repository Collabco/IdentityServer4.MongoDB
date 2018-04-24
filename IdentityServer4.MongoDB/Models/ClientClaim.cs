using MongoDB.Bson.Serialization.Attributes;

namespace IdentityServer4.MongoDB.Models
{
    public class ClientClaim
    {
        public ClientClaim()
        {

        }
        public ClientClaim(string type, string value)
        {
            Type = type;
            Value = value;
        }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }
    }
}