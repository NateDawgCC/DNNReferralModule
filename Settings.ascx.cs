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
using System.Globalization;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Modules.DNNReferralModule.Components;
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
                    
                    if (Settings.Contains("SearchParameter"))
                        txtSearchParameter.Text = Settings["SearchParameter"].ToString();

                    bool bEnableFallBackMode;
                    bool.TryParse(Settings.Contains("EnableFallBackMode") ? Settings["EnableFallBackMode"].ToString() : "false", out bEnableFallBackMode);

                    chkEnableFallBackMode.Checked = bEnableFallBackMode;

                    ddlFallBackMode.SelectedValue = Settings.Contains("FallBackMode") ? Settings["FallBackMode"].ToString() : Localization.GetString("Mode", LocalResourceFile, true);

                    ddlFallBackSortOrder.SelectedValue = Settings.Contains("FallBackSortOrder") ? Settings["FallBackSortOrder"].ToString() : Localization.GetString("SortOrder", LocalResourceFile, true);

                    if (Settings.Contains("StaticSearch"))
                        txtStaticSearch.Text = Settings["StaticSearch"].ToString();

                    ddlSortOrder.SelectedValue = Settings.Contains("SortOrder") ? Settings["SortOrder"].ToString() : Localization.GetString("SortOrder", LocalResourceFile, true);

                    txtNumberOfResults.Text = Settings.Contains("NumberOfResults") ? Settings["NumberOfResults"].ToString() : Localization.GetString("NumberOfResults", LocalResourceFile, true);

                    bool bEnableCache;
                    bool.TryParse(Settings.Contains("EnableCache") ? Settings["EnableCache"].ToString() : Localization.GetString("EnableCache", LocalResourceFile, true), out bEnableCache);

                    chkEnableCache.Checked = bEnableCache;
                    
                    txtCacheDuration.Text = Settings.Contains("CacheDuration") ? Settings["CacheDuration"].ToString() : Localization.GetString("CacheDuration", LocalResourceFile, true);
                    
                    txtPrimaryTemplate.Text = Settings.Contains("PrimaryTemplate") ? Settings["PrimaryTemplate"].ToString() : Localization.GetString("PrimaryTemplate", LocalResourceFile, true);

                    txtRowTemplate.Text = Settings.Contains("RowTemplate") ? Settings["RowTemplate"].ToString() : Localization.GetString("RowTemplate", LocalResourceFile, true);

                    txtPackageTemplate.Text = Settings.Contains("PackageTemplate") ? Settings["PackageTemplate"].ToString() : Localization.GetString("PackageTemplate", LocalResourceFile, true);

                    txtReviewTemplate.Text = Settings.Contains("ReviewTemplate") ? Settings["ReviewTemplate"].ToString() : Localization.GetString("ReviewTemplate", LocalResourceFile, true);

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
                modules.UpdateTabModuleSetting(TabModuleId, "VendorId", ddlVendor.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "PackageId", ddlProduct.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "SearchParameter", txtSearchParameter.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "EnableFallBackMode", chkEnableFallBackMode.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "FallBackMode", ddlFallBackMode.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "FallBackSortOrder", ddlFallBackSortOrder.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "StaticSearch", txtStaticSearch.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "SortOrder", ddlSortOrder.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "NumberOfResults", txtNumberOfResults.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "EnableCache", chkEnableCache.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "CacheDuration", txtCacheDuration.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "PrimaryTemplate", txtPrimaryTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "RowTemplate", txtRowTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "PackageTemplate", txtPackageTemplate.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "ReviewTemplate", txtReviewTemplate.Text);
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

        protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlFallBackMode_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void chkEnableCache_CheckedChanged(object sender, EventArgs e)
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

        protected void chkEnableFallBackMode_CheckedChanged(object sender, EventArgs e)
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

        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            try
            {
                DataCache.ClearCache("DNNReferralModule_");
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        private void LoadVendorList()
        {
            if (ddlVendor.Items.Count < 1)
            {
                ddlVendor.Items.Add(new ListItem(Localization.GetString("SelectOne", LocalResourceFile, true), "-1"));

                var serviceController = new ServiceController();
                var suppliers = serviceController.GetSupplierList();

                foreach (var supplierInfo in suppliers)
                {
                    ddlVendor.Items.Add(new ListItem(supplierInfo.SupplierName, supplierInfo.SupplierUserId));
                }

                if (Settings.Contains("VendorId"))
                {
                    if (ddlVendor.Items.FindByValue(Settings["VendorId"].ToString()) != null)
                    {
                        ddlVendor.SelectedValue = Settings["VendorId"].ToString();
                    }
                }
            }
        }

        private void LoadProductList(int supplierId)
        {
            var serviceController = new ServiceController();
            var products = serviceController.GetVendorsProducts(supplierId, 1000, "nameasc");

            ddlProduct.Items.Clear();

            ddlProduct.Items.Add(new ListItem(Localization.GetString("SelectOne", LocalResourceFile, true), "-1"));

            foreach (var productInfo in products)
            {
                ddlProduct.Items.Add(new ListItem(productInfo.PackageName, productInfo.PackageId.ToString(CultureInfo.InvariantCulture)));
            }

            if (Settings.Contains("PackageId"))
            {
                if (ddlProduct.Items.FindByValue(Settings["PackageId"].ToString()) != null)
                {
                    ddlProduct.SelectedValue = Settings["PackageId"].ToString();
                }
            }
        }

        private void SetVisibility()
        {
            var mode = ddlMode.SelectedValue;
            trSortOrder.Visible = false;
            trVendor.Visible = false;
            trProduct.Visible = false;
            trSearchParameter.Visible = false;
            trStaticSearch.Visible = false;
            trEnableFallBackMode.Visible = false;
            trSearchFallBack.Visible = false;
            trFallBackSortOrder.Visible = false;
            trPackageTemplate.Visible = false;
            trReviewTemplate.Visible = false;

            switch (mode)
            {
                case "TopModules":
                    trSortOrder.Visible = true;
                    trPackageTemplate.Visible = true;
                    ddlSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                    break;
                case "TopSkins":
                    trSortOrder.Visible = true;
                    trPackageTemplate.Visible = true;
                    ddlSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                    break;
                case "MyProducts":
                    trSortOrder.Visible = true;
                    trPackageTemplate.Visible = true;
                    LoadVendorList();
                    trVendor.Visible = true;
                    break;
                case "DynamicSearchResults":
                    trSortOrder.Visible = true;
                    trPackageTemplate.Visible = true;
                    ddlSortOrder.SelectedValue = "Relevance";
                    trSearchParameter.Visible = true;
                    trEnableFallBackMode.Visible = true;

                    if (chkEnableFallBackMode.Checked)
                    {
                        trSearchFallBack.Visible = true;
                        trFallBackSortOrder.Visible = true;

                        var fallbackMode = ddlFallBackMode.SelectedValue;
                        switch (fallbackMode)
                        {
                            case "TopModules":
                                ddlFallBackSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                                break;
                            case "TopSkins":
                                ddlFallBackSortOrder.SelectedValue = "RecentSalesRevenueDesc";
                                break;
                            case "MyProducts":
                                LoadVendorList();
                                trVendor.Visible = true;
                                break;
                            case "StaticSearchResults":
                                ddlFallBackSortOrder.SelectedValue = "Relevance";
                                trStaticSearch.Visible = true;
                                break;
                        }
                    }

                    break;
                case "StaticSearchResults":
                    trSortOrder.Visible = true;
                    trPackageTemplate.Visible = true;
                    ddlSortOrder.SelectedValue = "Relevance";
                    trStaticSearch.Visible = true;
                    break;
                case "FeaturedReviews":
                    trReviewTemplate.Visible = true;
                    break;
                case "SupplierReviews":
                    trReviewTemplate.Visible = true;
                    LoadVendorList();
                    trVendor.Visible = true;
                    break;
                case "PackageReviews":
                    trReviewTemplate.Visible = true;
                    LoadVendorList();
                    trVendor.Visible = true;
                    trProduct.Visible = true;

                    if (ddlVendor.SelectedValue != "-1")
                    {
                        ddlProduct.Items.Add(new ListItem(Localization.GetString("SelectOne", LocalResourceFile, true), "-1"));
                        
                        int vendorId;
                        int.TryParse(ddlVendor.SelectedValue, out vendorId);

                        if (vendorId > 0)
                        {
                            LoadProductList(vendorId);
                        }
                    }
                    break;
                default:
                    break;
            }

            trCacheDuration.Visible = chkEnableCache.Checked;
            trClearCache.Visible = chkEnableCache.Checked;
        }
    }
}