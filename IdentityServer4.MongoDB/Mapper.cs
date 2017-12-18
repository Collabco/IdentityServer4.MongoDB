using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IdentityServer4.MongoDB
{
    public static class Mapper
    {
        public static Models.Client ToEntity(this Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return new Models.Client
            {
                absoluteRefreshTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                accessTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                accessTokenType = (int)client.AccessTokenType,
                allowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                allowedCorsOrigins = client.AllowedCorsOrigins?.ToList(),
                allowedGrantTypes = client.AllowedGrantTypes?.ToList(),
                allowedScopes = client.AllowedScopes.ToList(),
                allowOfflineAccess = client.AllowOfflineAccess,
                allowPlainTextPkce = client.AllowPlainTextPkce,
                allowRememberConsent = client.AllowRememberConsent,
                alwaysIncludeUserClaimsInIdToken = client.AlwaysIncludeUserClaimsInIdToken,
                alwaysSendClientClaims = client.AlwaysSendClientClaims,
                authorizationCodeLifetime = client.AuthorizationCodeLifetime,
                claims = client.Claims?
                            .Select(c => new Models.ClientClaim(c.Type, c.Value))
                            .ToList(),
                clientId = client.ClientId,
                clientName = client.ClientName,
                clientSecrets = client.ClientSecrets?
                            .Select(c => new Models.ClientSecret
                            {
                                description = c.Description,
                                expiration = c.Expiration,
                                type = c.Type,
                                value = c.Value
                            })
                            .ToList(),
                clientUri = client.ClientUri,
                enabled = client.Enabled,
                enableLocalLogin = client.EnableLocalLogin,
                identityProviderRestrictions = client.IdentityProviderRestrictions?.ToList(),
                identityTokenLifetime = client.IdentityTokenLifetime,
                includeJwtId = client.IncludeJwtId,
                logoUri = client.LogoUri,
                logoutSessionRequired = client.LogoutSessionRequired,
                logoutUri = client.LogoutUri,
                postLogoutRedirectUris = client.PostLogoutRedirectUris?.ToList(),
                protocolType = client.ProtocolType,
                prefixClientClaims = client.PrefixClientClaims,
                updateAccessTokenClaimsOnRefresh = client.UpdateAccessTokenClaimsOnRefresh,
                slidingRefreshTokenLifetime = client.SlidingRefreshTokenLifetime,
                requirePkce = client.RequirePkce,
                requireConsent = client.RequirePkce,
                redirectUris = client.RedirectUris?.ToList(),
                RefreshTokenExpiration = (int)client.RefreshTokenExpiration,
                refreshTokenUsage = (int)client.RefreshTokenUsage,
                requireClientSecret = client.RequireClientSecret
            };
        }

        public static Client ToModel(this Models.Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return new Client
            {
                AbsoluteRefreshTokenLifetime = client.absoluteRefreshTokenLifetime,
                AccessTokenLifetime = client.absoluteRefreshTokenLifetime,
                AccessTokenType = (AccessTokenType)client.accessTokenType,
                AllowAccessTokensViaBrowser = client.allowAccessTokensViaBrowser,
                AllowedCorsOrigins = client.allowedCorsOrigins,
                AllowedGrantTypes = client.allowedGrantTypes,
                AllowedScopes = client.allowedScopes,
                AllowOfflineAccess = client.allowOfflineAccess,
                AllowPlainTextPkce = client.allowPlainTextPkce,
                AllowRememberConsent = client.allowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = client.alwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = client.alwaysSendClientClaims,
                AuthorizationCodeLifetime = client.authorizationCodeLifetime,
                Claims = client.claims?
                            .Select(c => new Claim(c.type, c.value))
                            .ToList() ?? new List<Claim>(),
                ClientId = client.clientId,
                ClientName = client.clientName,
                ClientSecrets = client.clientSecrets?
                            .Select(c => new Secret
                            {
                                Description = c.description,
                                Expiration = c.expiration,
                                Type = c.type,
                                Value = c.value
                            })
                            .ToList(),
                ClientUri = client.clientUri,
                Enabled = client.enabled,
                EnableLocalLogin = client.enableLocalLogin,
                IdentityProviderRestrictions = client.identityProviderRestrictions,
                IdentityTokenLifetime = client.identityTokenLifetime,
                IncludeJwtId = client.includeJwtId,
                LogoUri = client.logoUri,
                LogoutSessionRequired = client.logoutSessionRequired,
                LogoutUri = client.logoutUri,
                PostLogoutRedirectUris = client.postLogoutRedirectUris,
                ProtocolType = client.protocolType,
                PrefixClientClaims = client.prefixClientClaims,
                UpdateAccessTokenClaimsOnRefresh = client.updateAccessTokenClaimsOnRefresh,
                SlidingRefreshTokenLifetime = client.slidingRefreshTokenLifetime,
                RequirePkce = client.requirePkce,
                RequireConsent = client.requirePkce,
                RedirectUris = client.redirectUris,
                RefreshTokenExpiration = (TokenExpiration)client.RefreshTokenExpiration,
                RefreshTokenUsage = (TokenUsage)client.refreshTokenUsage,
                RequireClientSecret = client.requireClientSecret                
            };
        }

        public static Models.ApiResource ToEntity(this ApiResource model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Models.ApiResource(model.Name, model.DisplayName, model.UserClaims)
            {
                secrets = model.ApiSecrets?
                               .Select(c => new Models.ApiSecret
                               {
                                   type = c.Type,
                                   value = c.Value,
                                   description = c.Description,
                                   expiration = c.Expiration
                               })
                               .ToList(),
                enabled = model.Enabled,
                description = model.Description,
                scopes = model.Scopes?
                           .Select(c => new Models.ApiScope
                           {
                               description = c.Description,
                               displayName = c.DisplayName,
                               emphasize = c.Emphasize,
                               name = c.Name,
                               userClaims = c.UserClaims.ToList(),
                               required = c.Required,
                               showInDiscoveryDocument = c.ShowInDiscoveryDocument
                           })
                           .ToList()
            };
        }

        public static Models.IdentityResource ToEntity(this IdentityResource model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Models.IdentityResource(model.Name, model.DisplayName, model.UserClaims)
            {
                enabled = model.Enabled,
                description = model.Description,
                required = model.Required,
                emphasize = model.Emphasize,
                showInDiscoveryDocument = model.ShowInDiscoveryDocument
            };
        }

        public static ApiResource ToModel(this Models.ApiResource model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ApiResource(model.name, model.displayName, model.userClaims)
            {
                ApiSecrets = model.secrets?
                                .Select(c => new Secret(c.value, c.description, c.expiration)
                                {
                                    Type = c.type
                                })
                                .ToList(),
                Enabled = model.enabled,
                Description = model.description,
                Scopes = model.scopes?
                            .Select(c => new Scope
                            {
                                Description = c.description,
                                DisplayName = c.displayName,
                                Emphasize = c.emphasize,
                                Name = c.name,
                                UserClaims = c.userClaims,
                                Required = c.required,
                                ShowInDiscoveryDocument = c.showInDiscoveryDocument
                            })
                            .ToList()
            };
        }

        public static IdentityResource ToModel(this Models.IdentityResource model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new IdentityResource(model.name, model.displayName, model.userClaims)
            {
                Enabled = model.enabled,
                Description = model.description,
                Required = model.required,
                Emphasize = model.emphasize,
                ShowInDiscoveryDocument = model.showInDiscoveryDocument
            };
        }

    }
}