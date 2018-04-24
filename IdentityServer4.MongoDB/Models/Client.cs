using IdentityServer4.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer4.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class Client : ConfigObject
    {
        public Client()
        {
        }
        
        public int absoluteRefreshTokenLifetime { get; set; } = 2592000;
        public int accessTokenLifetime { get; set; } = 3600;
        public int accessTokenType { get; set; } = (int)0;
        public bool allowAccessTokensViaBrowser { get; set; }
        public List<string> allowedCorsOrigins { get; set; }
        public List<string> allowedGrantTypes { get; set; }
        public List<string> allowedScopes { get; set; }
        public bool allowOfflineAccess { get; set; }
        public bool allowPlainTextPkce { get; set; }
        public bool allowRememberConsent { get; set; } = true;
        public bool alwaysIncludeUserClaimsInIdToken { get; set; }
        public bool alwaysSendClientClaims { get; set; }
        public int authorizationCodeLifetime { get; set; } = 300;
        public List<ClientClaim> claims { get; set; }
        [BsonId]
        public string clientId { get; set; }
        public string clientName { get; set; }
        public List<ClientSecret> clientSecrets { get; set; }
        public string clientUri { get; set; }
        public bool enabled { get; set; } = true;
        // AccessTokenType.Jwt;
        public bool enableLocalLogin { get; set; } = true;
        public List<string> identityProviderRestrictions { get; set; }
        public int identityTokenLifetime { get; set; } = 300;
        public bool includeJwtId { get; set; }
        public string logoUri { get; set; }
        public bool logoutSessionRequired { get; set; } = true;
        public string logoutUri { get; set; }
        public List<string> postLogoutRedirectUris { get; set; }
        public bool prefixClientClaims { get; set; } = true;
        public string protocolType { get; set; } = ProtocolTypes.OpenIdConnect;
        public List<string> redirectUris { get; set; }
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;
        public int refreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;
        public bool requireClientSecret { get; set; } = true;
        public bool requireConsent { get; set; } = true;
        public bool requirePkce { get; set; }
        public int slidingRefreshTokenLifetime { get; set; } = 1296000;
        public bool updateAccessTokenClaimsOnRefresh { get; set; }
    }
}