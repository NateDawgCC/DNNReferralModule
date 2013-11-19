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
using System.Collections.Generic;
using System.Globalization;
using DotNetNuke.Modules.DNNReferralModule.Components;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

namespace DotNetNuke.Modules.DNNReferralModule
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from DNNReferralModuleModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : DNNReferralModuleModuleBase
    {
        private readonly String _settingsLocalResource;

        public View()
        {
            _settingsLocalResource = "/DesktopModules/DNNReferralModule/App_LocalResources/Settings.ascx.resx";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack) return;
                
                var mode = GetSettingOrDefault("Mode");
                var sortOrder = GetSettingOrDefault("SortOrder");
                var sNumberOfResults = GetSettingOrDefault("NumberOfResults");
                int numberOfResults;

                int.TryParse(sNumberOfResults, out numberOfResults);

                var sEnableCache = GetSettingOrDefault("EnableCache");
                bool enableCache;

                bool.TryParse(sEnableCache, out enableCache);

                var sCacheDuration = GetSettingOrDefault("CacheDuration");
                int cacheDuration;

                int.TryParse(sCacheDuration, out cacheDuration);

                if (cacheDuration < 0)
                {
                    cacheDuration = 0;
                }

                var serviceController = new ServiceController
                    {
                        Referer = Request.Url.ToString(),
                        EnableCache = enableCache,
                        CacheDuration = cacheDuration
                    };

                switch (mode)
                {
                    case "FeaturedReviews":
                    case "SupplierReviews":
                    case "PackageReviews":
                        var reviewResults = GetReviewResults(mode, serviceController, numberOfResults);

                        RenderReviewOutput(reviewResults);
                        break;
                    default:
                        var packageResults = GetPackageResults(mode, serviceController, numberOfResults, sortOrder);

                        RenderPackageOutput(packageResults);
                        break;
                }

                var referralCode = Settings.Contains("ReferralCode") ? Settings["ReferralCode"].ToString() : string.Empty;
            
                if (string.IsNullOrEmpty(referralCode) && IsEditable)
                {
                    litMessage.Visible = true;
                    litMessage.Text = Localization.GetString("ProvideReferralCode", LocalResourceFile);
                }
            }
            catch (Exception ex) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        private List<PackageInfo> GetPackageResults(string mode, ServiceController serviceController, int numberOfResults, string sortOrder)
        {
            var results = new List<PackageInfo>();

            switch (mode)
            {
                case "TopModules":
                    results = serviceController.GetTopModules(numberOfResults, sortOrder);
                    break;
                case "TopSkins":
                    results = serviceController.GetTopSkins(numberOfResults, sortOrder);
                    break;
                case "MyProducts":
                    var sVendorId = Settings.Contains("VendorId") ? Settings["VendorId"].ToString() : "";
                    int vendorId;

                    int.TryParse(sVendorId, out vendorId);

                    results = serviceController.GetVendorsProducts(vendorId, numberOfResults, sortOrder);
                    break;
                case "DynamicSearchResults":
                    var searchParameter = Settings.Contains("SearchParameter")
                                              ? Settings["SearchParameter"].ToString()
                                              : string.Empty;

                    if (!String.IsNullOrEmpty(searchParameter))
                    {
                        if (!String.IsNullOrEmpty(Request.QueryString[searchParameter]))
                        {
                            var searchText = Request.QueryString[searchParameter];
                            results = serviceController.GetProductsBySearch(searchText, numberOfResults, sortOrder);
                        }
                    }

                    if (results.Count <= 0)
                    {
                        var sEnableFallBackMode = GetSettingOrDefault("EnableFallBackMode");
                        bool enableFallBackMode;

                        bool.TryParse(sEnableFallBackMode, out enableFallBackMode);
                        if (enableFallBackMode)
                        {
                            var fallBackMode = GetSettingOrDefault("FallBackMode");
                            var fallBackSortOrder = GetSettingOrDefault("FallBackSortOrder");

                            results = GetPackageResults(fallBackMode, serviceController, numberOfResults, fallBackSortOrder);
                        }
                    }

                    break;
                case "StaticSearchResults":
                    var staticSearchText = Settings.Contains("StaticSearch")
                                               ? Settings["StaticSearch"].ToString()
                                               : string.Empty;

                    if (!String.IsNullOrEmpty(staticSearchText))
                    {
                        results = serviceController.GetProductsBySearch(staticSearchText, numberOfResults, sortOrder);
                    }

                    break;
                default:
                    litOutput.Text = Localization.GetString("pleaseConfig", LocalResourceFile);
                    break;
            }
            return results;
        }

        private List<ReviewInfo> GetReviewResults(string mode, ServiceController serviceController, int numberOfResults)
        {
            var results = new List<ReviewInfo>();

            switch (mode)
            {
                case "FeaturedReviews":
                    results = serviceController.GetFeaturedReviews(numberOfResults, "submitdatedesc");
                    break;
                case "SupplierReviews":
                    int supplierId;
                    int.TryParse(GetSettingOrDefault("VendorId"), out supplierId);

                    results = serviceController.GetSupplierReviews(supplierId, numberOfResults, "submitdatedesc");
                    break;
                case "PackageReviews":
                    int packageId;
                    int.TryParse(GetSettingOrDefault("PackageId"), out packageId);

                    results = serviceController.GetPackageReviews(packageId, numberOfResults, "submitdatedesc");
                    break;
                default:
                    litOutput.Text = Localization.GetString("pleaseConfig", LocalResourceFile);
                    break;
            }
            return results;
        }

        void RenderPackageOutput(ICollection<PackageInfo> items)
        {
            if (items == null || items.Count <= 0)
            {
                litOutput.Text = GetSettingOrDefault("NoResultsTemplate");
            }
            else
            {
                var packageTemplate = GetSettingOrDefault("PackageTemplate");
                var rowTemplate = GetSettingOrDefault("RowTemplate");
                var primaryTemplate = GetSettingOrDefault("PrimaryTemplate");
                var referralCode = Settings.Contains("ReferralCode") ? Settings["ReferralCode"].ToString() : "";

                var rows = "";

                foreach (var item in items)
                {
                    var itemOutput = packageTemplate;
                    itemOutput = itemOutput.Replace("[PackageId]", item.PackageId.ToString(CultureInfo.InvariantCulture));
                    itemOutput = itemOutput.Replace("[PackageName]", item.PackageName);
                    itemOutput = !string.IsNullOrEmpty(referralCode)
                                     ? itemOutput.Replace("[PackageLink]", item.PackageLink + "?r=" + referralCode)
                                     : itemOutput.Replace("[PackageLink]", item.PackageLink);
                    itemOutput = itemOutput.Replace("[PackagePrice]", item.PackagePrice);
                    itemOutput = itemOutput.Replace("[PackageIcon]", item.PackageIcon);
                    itemOutput = itemOutput.Replace("[PackageRatingNumber]",
                                                    item.PackageRatingNumber.ToString(CultureInfo.InvariantCulture));
                    itemOutput = itemOutput.Replace("[PackageRatingImage]", item.PackageRatingImage);
                    itemOutput = itemOutput.Replace("[VendorName]", item.VendorName);
                    itemOutput = !string.IsNullOrEmpty(referralCode)
                                     ? itemOutput.Replace("[VendorLink]", item.VendorLink + "?r=" + referralCode)
                                     : itemOutput.Replace("[VendorLink]", item.VendorLink);

                    if (!rows.Contains("[ItemTemplate]"))
                    {
                        rows += rowTemplate;
                    }

                    rows = ReplaceFirst(rows, "[ItemTemplate]", itemOutput);
                }

                rows = rows.Replace("[ItemTemplate]", "&nbsp;");

                litOutput.Text = primaryTemplate.Replace("[RowTemplate]", rows);
            }
        }

        void RenderReviewOutput(ICollection<ReviewInfo> items)
        {
            if (items == null || items.Count <= 0)
            {
                litOutput.Text = GetSettingOrDefault("NoResultsTemplate");
            }
            else
            {
                var reviewTemplate = GetSettingOrDefault("ReviewTemplate");
                var rowTemplate = GetSettingOrDefault("RowTemplate");
                var primaryTemplate = GetSettingOrDefault("PrimaryTemplate");
                var referralCode = Settings.Contains("ReferralCode") ? Settings["ReferralCode"].ToString() : "";

                var rows = "";

                foreach (var item in items)
                {
                    var itemOutput = reviewTemplate;
                    itemOutput = itemOutput.Replace("[ReviewId]", item.ReviewId.ToString(CultureInfo.InvariantCulture));
                    itemOutput = itemOutput.Replace("[PackageName]", item.PackageName);
                    itemOutput = !string.IsNullOrEmpty(referralCode)
                                     ? itemOutput.Replace("[PackageLink]", item.PackageLink + "?r=" + referralCode)
                                     : itemOutput.Replace("[PackageLink]", item.PackageLink);
                    itemOutput = itemOutput.Replace("[PackageIcon]", item.PackageIcon);
                    itemOutput = itemOutput.Replace("[Rating]", item.Rating.ToString(CultureInfo.InvariantCulture));
                    itemOutput = itemOutput.Replace("[Review]", item.Review);
                    itemOutput = itemOutput.Replace("[ReviewerName]", item.ReviewerName);
                    itemOutput = !string.IsNullOrEmpty(referralCode)
                                     ? itemOutput.Replace("[ReviewerLink]", item.ReviewerLink + "?r=" + referralCode)
                                     : itemOutput.Replace("[ReviewerLink]", item.ReviewerLink);
                    itemOutput = itemOutput.Replace("[Reply]", item.Reply);
                    itemOutput = itemOutput.Replace("[Date]", item.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                    itemOutput = itemOutput.Replace("[RatingImage]", item.RatingImage);
                    itemOutput = itemOutput.Replace("[VendorName]", item.VendorName);
                    itemOutput = !string.IsNullOrEmpty(referralCode)
                                     ? itemOutput.Replace("[VendorLink]", item.VendorLink + "?r=" + referralCode)
                                     : itemOutput.Replace("[VendorLink]", item.VendorLink);

                    if (!rows.Contains("[ItemTemplate]"))
                    {
                        rows += rowTemplate;
                    }

                    rows = ReplaceFirst(rows, "[ItemTemplate]", itemOutput);
                }

                rows = rows.Replace("[ItemTemplate]", "&nbsp;");

                litOutput.Text = primaryTemplate.Replace("[RowTemplate]", rows);
            }
        }

        static string ReplaceFirst(string text, string search, string replace)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private string GetSettingOrDefault(string key)
        {
            var returnValue = "";
            if (Settings.Contains(key))
                returnValue = Settings[key].ToString();

            if (String.IsNullOrEmpty(returnValue))
                returnValue = Localization.GetString(key, _settingsLocalResource, true);

            return returnValue;
        }
    }
}