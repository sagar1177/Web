// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using IdentityServer4.Models;

namespace SignOn.Web.Controllers.Home
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }

        public ErrorViewModel(string error)
        {
            this.Error = new ErrorMessage { Error = error };
        }

        public ErrorMessage Error { get; set; }
    }
}