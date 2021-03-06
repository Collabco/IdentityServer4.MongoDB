﻿using global::MongoDB.Bson;
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

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("displayName")]
        public string DisplayName { get; set; }

        [BsonElement("enabled")]
        public bool Enabled { get; set; } = true;

        [BsonId]
        public string Name { get; set; }

        [BsonElement("scopes")]
        public List<ApiScope> Scopes { get; set; }

        [BsonElement("secrets")]
        public List<ApiSecret> Secrets { get; set; }

        [BsonElement("userClaims")]
        public List<string> UserClaims { get; set; }
    }
}