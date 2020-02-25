// <copyright file="ConsentInputModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace SignOn.Web.Controllers.Consent
{
    public class ConsentInputModel
    {
        public string Button { get; set; }

        public IEnumerable<string> ScopesConsented { get; set; }

        public bool RememberConsent { get; set; }

        public string ReturnUrl { get; set; }
    }
}