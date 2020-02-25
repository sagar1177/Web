// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using IdentityServer4.Models;
using System.Collections.Generic;

namespace SignOn.Web.Configurations
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "office",
                    UserClaims =
                    {
                        "office_number"
                    }
                }
            };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                // new ApiResource("ApiOne"),
                // new ApiResource("ApiTwo", new string[] { "rc.api.garndma" }),
            };

        public static IEnumerable<Client> GetClients() =>
            new Client[]
            {

                new Client
                {
                    ClientId = "Web",
                    ClientName ="mvc demo",
                    AllowedGrantTypes ={
                            GrantType.Hybrid,
                            GrantType.ClientCredentials
                        },
                     AllowAccessTokensViaBrowser = true,
                        RedirectUris = { "http://localhost/Web/signin-oidc" },
                        ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost/Web/signout-callback-oidc" },
                    AllowedScopes = { "openid", "email" ,"office","profile"},
                    RequireConsent = false,
                                    AllowOfflineAccess = true
                },

                new Client
            {
                ClientId = "mvc4",
                ClientName = "MVC 4 Web Client",
                AllowedGrantTypes = {
                    GrantType.Hybrid,
                    GrantType.ClientCredentials
                },
                AllowAccessTokensViaBrowser = true,

                RequireConsent = false,

                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                RedirectUris = { "http://localhost:53173/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:53173/signout-callback-oidc" },

                AllowedScopes = { "openid", "email" ,"office","profile"},
                AllowOfflineAccess = true
            }

            };
    }
}