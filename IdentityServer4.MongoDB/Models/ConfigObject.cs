using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.MongoDB.Models
{
    [BsonKnownTypes(typeof(Client), typeof(ApiResource), typeof(IdentityResource))]
    public class ConfigObject
    {
        public ConfigObject()
        {
        }
    }
}
