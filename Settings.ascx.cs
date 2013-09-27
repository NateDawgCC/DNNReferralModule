// 
// DNN Corp. - http://www.dnnsoftware.com
// Copyright (c) 2002-2013 DNN  Corp.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

namespace DotNetNuke.Modules.DNNReferralModule
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from DNNReferralModuleSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : DNNReferralModuleModuleSettingsBase
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    if (Settings.Contains("ReferralCode"))
                        txtReferralCode.Text = Settings["ReferralCode"].ToString();

                    ddlMode.SelectedValue = Settings.Contains("Mode") ? Settings["Mode"].ToString() : Localization.GetString("Mode", LocalResourceFile, true);

                    if (Settings.Contains("VendorId"))
                        txtVendorId.Text = Settings["VendorId"].ToString();

                    if (Settings.Contains("SearchParameter"))
                        txtSearchParameter.Text = Settings["SearchParameter"].ToString();

                    ddlSortOrder.SelectedValue = Settings.Contains("SortOrder") ? Settings["SortOrder"].ToString() : Localization.GetString("SortOrder", LocalResourceFile, true);

                    txtNumberOfResults.Text = Settings.Contains("NumberOfResults") ? Settings["NumberOfResults"].ToString() : Localization.GetString("NumberOfResults", LocalResourceFile, true);

                    txtPrimaryTemplate.Text = Settings.Contains("PrimaryTemplate") ? Settings["PrimaryTemplate"].ToString() : Localization.GetString("PrimaryTemplate", LocalResourceFile, true);

                    txtRowTemplate.Text = Settings.Contains("RowTemplate") ? Settings["RowTemplate"].ToString() : Localization.GetString("RowTemplate", LocalResourceFile, true);

                    txtItemTemplate.Text = Settings.Contains("ItemTemplate") ? Settings["ItemTemplate"].ToString() : Localization.GetString("ItemTemplate", LocalResourceFile, true);

                    txtNoResultsTemplate.Text = Settings.Contains("NoResultsTemplate") ? Settings["NoResultsTemplate"].ToString() : Localization.GetString("NoResultsTemplate", LocalResourceFile, true);

                    SetVisibility();
                }
            }
            catch (Exception ex) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                modules.UpdateTabModuleSetting(TabModuleId, "ReferralCode", txtReferralCode.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "Mode", ddlMode.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "VendorId", txtVendorId.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "SearchParameter", txtSearchParameter.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "SortOrder", ddlSortOrder.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "NumberOfResults", txtNumberOfResults.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "PrimaryTemplate", txtPrimaryTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "RowTemplate", txtRowTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "ItemTemplate", txtItemTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "NoResultsTemplate", txtNoResultsTemplate.Text);
            }
            catch (Exception ex) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetVisibility();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        private void SetVisibility()
        {
            var mode = ddlMode.SelectedValue;

            trVendorId.Visible = false;
            trSearchParameter.Visible = false;

            switch (mode)
            {
                case "TopModules":
                    ddlSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                    break;
                case "TopSkins":
                    ddlSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                    break;
                case "MyProducts":
                    trVendorId.Visible = true;
                    break;
                case "SearchResults":
                    ddlSortOrder.SelectedValue = "Relevance";
                    trSearchParameter.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}