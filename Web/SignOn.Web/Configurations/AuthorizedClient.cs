// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizedClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using SignOn.Web.Configurations;
using System.Collections.Generic;

namespace Civica.Cito.SignOn.Configuration
{
    /// <summary>
    /// This Class represent the relying Party Which could Authenicate from Sing on Site
    /// </summary>
    public class AuthorizedClient
    {
        public string RedirectUri { get; set; }

        public string FrontChannelLogoutUri { get; set; }

        public string ClientId { get; set; }

        public string Protocol { get; set; }

        public int TokenLifetime { get; set; }

        public int? AccessTokenLifeTime { get; set; }

        public IEnumerable<GrantType> GrantTypes { get; set; }

        public IEnumerable<Scope> Scopes { get; set; }

        public ClientSecret Secret { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }
    }
}
