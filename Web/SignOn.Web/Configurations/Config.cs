// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Civica.Cito.SignOn.Configuration;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace SignOn.Web.Configurations
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> GetApiResources(IConfiguration configuration)
        {
            var apis = new List<Api>();
            configuration.GetSection("ApiResource").Get<List<Api>>();

            var apiResources = new List<ApiResource>();
            foreach (var api in apis)
            {
                apiResources.Add(new ApiResource(api.ApiName, api.ApiName)
                {
                    ApiSecrets = { new Secret(api.Secret.Value.Sha256()) }
                });
            }

            return apiResources.ToArray();
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            var relyingParties = new List<AuthorizedClient>();

            relyingParties = configuration.GetSection("AuthorizedClient").Get<List<AuthorizedClient>>();

            var clients = new List<Client>();
            foreach (var relyingParty in relyingParties)
            {
                var client = new Client();
                client.ClientId = relyingParty.ClientId;

                if (!string.IsNullOrEmpty(relyingParty.Protocol))
                {
                    client.ProtocolType = relyingParty.Protocol;
                }

                if (!string.IsNullOrEmpty(relyingParty.RedirectUri))
                {
                    client.RedirectUris = new List<string> { relyingParty.RedirectUri };
                }

                if (!string.IsNullOrEmpty(relyingParty.FrontChannelLogoutUri))
                {
                    client.PostLogoutRedirectUris = new List<string> { relyingParty.FrontChannelLogoutUri };
                    client.BackChannelLogoutUri = relyingParty.FrontChannelLogoutUri;
                }

                client.RequireConsent = false;

                if (relyingParty.GrantTypes.Any())
                {
                    client.AllowedGrantTypes = relyingParty.GrantTypes.Select(x => x.GrantTypeId).ToList();
                }

                client.IdentityTokenLifetime = relyingParty.TokenLifetime;

                if (relyingParty.AccessTokenLifeTime != null)
                {
                    client.AccessTokenLifetime = relyingParty.AccessTokenLifeTime.Value;
                }

                if (relyingParty.Scopes != null && relyingParty.Scopes.Count() > 0)
                {
                    client.AllowedScopes = relyingParty.Scopes.Select(x => x.ScopeId).ToList();
                }

                if (relyingParty.Secret != null)
                {
                    client.ClientSecrets = new Secret[] { new Secret(relyingParty.Secret.Value.Sha256()) };
                }

                client.AllowAccessTokensViaBrowser = true;

                client.AlwaysIncludeUserClaimsInIdToken = true;

                clients.Add(client);
            }

            return clients.ToArray();
        }
    }
}