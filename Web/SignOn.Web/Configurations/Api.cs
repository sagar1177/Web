// <copyright file="Api.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SignOn.Web.Configurations
{
    /// <summary>
    /// This class represent the Api which is being authenicate agaist the sign on.
    /// </summary>
    public class Api
    {
        public string ApiName { get; set; }

        public ClientSecret Secret { get; set; }
    }
}
