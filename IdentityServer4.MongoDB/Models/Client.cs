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
        /// <summary>
        /// Specifies if client is enabled (defaults to <c>true</c>)
        /// </summary>
        [BsonElement("enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Unique ID of the client
        /// </summary>
        [BsonId]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the protocol type.
        /// </summary>
        /// <value>
        /// The protocol type.
        /// </value>
        [BsonElement("protocolType")]
        public string ProtocolType { get; set; } = IdentityServerConstants.ProtocolTypes.OpenIdConnect;

        /// <summary>
        /// Client secrets - only relevant for flows that require a secret
        /// </summary>
        [BsonElement("clientSecrets")]
        public ICollection<ClientSecret> ClientSecrets { get; set; }

        /// <summary>
        /// If set to false, no client secret is needed to request tokens at the token endpoint (defaults to <c>true</c>)
        /// </summary>
        [BsonElement("requireClientSecret")]
        public bool RequireClientSecret { get; set; } = true;

        /// <summary>
        /// Client display name (used for logging and consent screen)
        /// </summary>        
        [BsonElement("clientName")]
        public string ClientName { get; set; }

        /// <summary>
        /// URI to further information about client (used on consent screen)
        /// </summary>
        [BsonElement("clientUri")]
        public string ClientUri { get; set; }

        /// <summary>
        /// URI to client logo (used on consent screen)
        /// </summary>
        [BsonElement("logoUri")]
        public string LogoUri { get; set; }

        /// <summary>
        /// Specifies whether a consent screen is required (defaults to <c>true</c>)
        /// </summary>
        [BsonElement("requireConsent")]
        public bool RequireConsent { get; set; } = true;

        /// <summary>
        /// Specifies whether user can choose to store consent decisions (defaults to <c>true</c>)
        /// </summary>
        [BsonElement("allowRememberConsent")]
        public bool AllowRememberConsent { get; set; } = true;

        /// <summary>
        /// Specifies the allowed grant types (legal combinations of AuthorizationCode, Implicit, Hybrid, ResourceOwner, ClientCredentials).
        /// </summary>
        [BsonElement("allowedGrantTypes")]
        public ICollection<string> AllowedGrantTypes { get; set; }

        /// <summary>
        /// Specifies whether a proof key is required for authorization code based token requests (defaults to <c>false</c>).
        /// </summary>
        [BsonElement("requirePkce")]
        public bool RequirePkce { get; set; }

        /// <summary>
        /// Specifies whether a proof key can be sent using plain method (not recommended and defaults to <c>false</c>.)
        /// </summary>
        [BsonElement("allowPlainTextPkce")]
        public bool AllowPlainTextPkce { get; set; }

        /// <summary>
        /// Controls whether access tokens are transmitted via the browser for this client (defaults to <c>false</c>).
        /// This can prevent accidental leakage of access tokens when multiple response types are allowed.
        /// </summary>
        /// <value>
        /// <c>true</c> if access tokens can be transmitted via the browser; otherwise, <c>false</c>.
        /// </value>
        [BsonElement("allowAccessTokensViaBrowser")]
        public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// Specifies allowed URIs to return tokens or authorization codes to
        /// </summary>
        [BsonElement("redirectUris")]
        public ICollection<string> RedirectUris { get; set; } = new HashSet<string>();

        /// <summary>
        /// Specifies allowed URIs to redirect to after logout
        /// </summary>
        [BsonElement("postLogoutRedirectUris")]
        public ICollection<string> PostLogoutRedirectUris { get; set; } = new HashSet<string>();

        /// <summary>
        /// Specifies logout URI at client for HTTP front-channel based logout.
        /// </summary>
        [BsonElement("frontChannelLogoutUri")]
        public string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// Specifies is the user's session id should be sent to the FrontChannelLogoutUri. Defaults to <c>true</c>.
        /// </summary>
        [BsonElement("frontChannelLogoutSessionRequired")]
        public bool? FrontChannelLogoutSessionRequired { get; set; } //= true;

        /// <summary>
        /// Specifies logout URI at client for HTTP back-channel based logout.
        /// </summary>
        [BsonElement("backChannelLogoutUri")]
        public string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// Specifies is the user's session id should be sent to the BackChannelLogoutUri. Defaults to <c>true</c>.
        /// </summary>
        [BsonElement("backChannelLogoutSessionRequired")]
        public bool? BackChannelLogoutSessionRequired { get; set; } //= true;

        /// <summary>
        /// Gets or sets a value indicating whether [allow offline access]. Defaults to <c>false</c>.
        /// </summary>
        [BsonElement("allowOfflineAccess")]
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope
        /// </summary>
        [BsonElement("allowedScopes")]
        public ICollection<string> AllowedScopes { get; set; }

        /// <summary>
        /// When requesting both an id token and access token, should the user claims always be added to the id token instead of requring the client to use the userinfo endpoint.
        /// Defaults to <c>false</c>.
        /// </summary>
        [BsonElement("alwaysIncludeUserClaimsInIdToken")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>
        /// Lifetime of identity token in seconds (defaults to 300 seconds / 5 minutes)
        /// </summary>
        [BsonElement("identityTokenLifetime")]
        public int IdentityTokenLifetime { get; set; } = 300;

        /// <summary>
        /// Lifetime of access token in seconds (defaults to 3600 seconds / 1 hour)
        /// </summary>
        [BsonElement("accessTokenLifetime")]
        public int AccessTokenLifetime { get; set; } = 3600;

        /// <summary>
        /// Lifetime of authorization code in seconds (defaults to 300 seconds / 5 minutes)
        /// </summary>
        [BsonElement("authorizationCodeLifetime")]
        public int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// Maximum lifetime of a refresh token in seconds. Defaults to 2592000 seconds / 30 days
        /// </summary>
        [BsonElement("absoluteRefreshTokenLifetime")]
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        /// <summary>
        /// Sliding lifetime of a refresh token in seconds. Defaults to 1296000 seconds / 15 days
        /// </summary>
        [BsonElement("slidingRefreshTokenLifetime")]
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        /// <summary>
        /// Lifetime of a user consent in seconds. Defaults to null (no expiration)
        /// </summary>
        [BsonElement("consentLifetime")]
        public int? ConsentLifetime { get; set; }

        /// <summary>
        /// ReUse: the refresh token handle will stay the same when refreshing tokens
        /// OneTime: the refresh token handle will be updated when refreshing tokens
        /// </summary>
        [BsonElement("refreshTokenUsage")]
        public int RefreshTokenUsage { get; set; } = (int)IdentityServer4.Models.TokenUsage.OneTimeOnly;

        /// <summary>
        /// Gets or sets a value indicating whether the access token (and its claims) should be updated on a refresh token request.
        /// Defaults to <c>false</c>.
        /// </summary>
        /// <value>
        /// <c>true</c> if the token should be updated; otherwise, <c>false</c>.
        /// </value>
        [BsonElement("updateAccessTokenClaimsOnRefresh")]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>
        /// Absolute: the refresh token will expire on a fixed point in time (specified by the AbsoluteRefreshTokenLifetime)
        /// Sliding: when refreshing the token, the lifetime of the refresh token will be renewed (by the amount specified in SlidingRefreshTokenLifetime). The lifetime will not exceed AbsoluteRefreshTokenLifetime.
        /// </summary>        
        [BsonElement("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;

        /// <summary>
        /// Specifies whether the access token is a reference token or a self contained JWT token (defaults to Jwt).
        /// </summary>
        [BsonElement("accessTokenType")]
        public int AccessTokenType { get; set; } = (int)IdentityServer4.Models.AccessTokenType.Jwt;

        /// <summary>
        /// Gets or sets a value indicating whether the local login is allowed for this client. Defaults to <c>true</c>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if local logins are enabled; otherwise, <c>false</c>.
        /// </value>
        [BsonElement("enableLocalLogin")]
        public bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// Specifies which external IdPs can be used with this client (if list is empty all IdPs are allowed). Defaults to empty.
        /// </summary>
        [BsonElement("identityProviderRestrictions")]
        public ICollection<string> IdentityProviderRestrictions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether JWT access tokens should include an identifier. Defaults to <c>false</c>.
        /// </summary>
        /// <value>
        /// <c>true</c> to add an id; otherwise, <c>false</c>.
        /// </value>
        [BsonElement("includeJwtId")]
        public bool IncludeJwtId { get; set; }

        /// <summary>
        /// Allows settings claims for the client (will be included in the access token).
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        [BsonElement("claims")]
        public ICollection<ClientClaim> Claims { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether client claims should be always included in the access tokens - or only for client credentials flow.
        /// Defaults to <c>false</c>
        /// </summary>
        /// <value>
        /// <c>true</c> if claims should always be sent; otherwise, <c>false</c>.
        /// </value>
        [BsonElement("alwaysSendClientClaims")]
        public bool AlwaysSendClientClaims { get; set; }

        /// <summary>
        /// Gets or sets a value to prefix it on client claim types. Defaults to <c>client_</c>.
        /// </summary>
        /// <value>
        /// Any non empty string if claims should be prefixed with the value; otherwise, <c>null</c>.
        /// </value>
        [BsonElement("clientClaimsPrefix")]
        public string ClientClaimsPrefix { get; set; } //= "client_";

        /// <summary>
        /// Gets or sets a salt value used in pair-wise subjectId generation for users of this client.
        /// </summary>
        [BsonElement("pairWiseSubjectSalt")]
        public string PairWiseSubjectSalt { get; set; }

        /// <summary>
        /// Gets or sets the allowed CORS origins for JavaScript clients.
        /// </summary>
        /// <value>
        /// The allowed CORS origins.
        /// </value>
        [BsonElement("allowedCorsOrigins")]
        public ICollection<string> AllowedCorsOrigins { get; set; }

        /// <summary>
        /// Gets or sets the custom properties for the client.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        [BsonElement("properties")]
        public IDictionary<string, string> Properties { get; set; }

        //************* Backwards compatability properties **************

        /// <summary>
        /// Backwards campatability property to default front and back channel versions
        /// </summary>
        [BsonElement("logoutUri")]
        public string DefaultLogoutUri { get; set; }

        /// <summary>
        /// Backwards campatability property to default front and back channel versions
        /// </summary>
        [BsonElement("logoutSessionRequired")]
        public bool DefaultLogoutSessionRequired { get; set; } = true;


        [BsonElement("prefixClientClaims")]
        public bool PrefixClientClaims { get; set; } = true;
    }
}