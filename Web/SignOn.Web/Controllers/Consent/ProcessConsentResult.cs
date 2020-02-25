// <copyright file="ProcessConsentResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SignOn.Web.Controllers.Consent
{
    public class ProcessConsentResult
    {
        public bool IsRedirect => RedirectUri != null;

        public string RedirectUri { get; set; }

        public string ClientId { get; set; }

        public bool ShowView => ViewModel != null;

        public ConsentViewModel ViewModel { get; set; }

        public bool HasValidationError => ValidationError != null;

        public string ValidationError { get; set; }
    }
}
