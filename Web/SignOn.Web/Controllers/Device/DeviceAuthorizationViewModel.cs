// <copyright file="DeviceAuthorizationViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SignOn.Web.Controllers.Consent;

namespace SignOn.Web.Controllers.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }

        public bool ConfirmUserCode { get; set; }
    }
}