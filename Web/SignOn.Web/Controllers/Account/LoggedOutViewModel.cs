// <copyright file="LoggedOutViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SignOn.Web.Controllers.Account
{
    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri { get; set; }

        public string ClientName { get; set; }

        public string SignOutIframeUrl { get; set; }

        public bool AutomaticRedirectAfterSignOut { get; set; }

        public string LogoutId { get; set; }

        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;

        public string ExternalAuthenticationScheme { get; set; }
    }
}