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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using DotNetNuke.Common.Utilities;
using Newtonsoft.Json.Linq;

namespace DotNetNuke.Modules.DNNReferralModule.Components
{
    public class ServiceController
    {
        public string Referer { get; set; }
        public bool EnableCache { get; set; }
        public int CacheDuration { get; set; }
        
        private object GetTopModulesCallback(CacheItemArgs cacheItemArgs)
        {
            var numberOfResults = (int)cacheItemArgs.ParamList[0];
            var orderBy = (string)cacheItemArgs.ParamList[1];

            return GetTopModulesResults(numberOfResults, orderBy);
        }

        public List<PackageInfo> GetTopModules(int numberOfResults, string orderBy)
        {
            if (EnableCache)
            {
                return CBO.GetCachedObject<List<PackageInfo>>(new CacheItemArgs("DNNReferralModule_GetTopModules_results_" + numberOfResults + "_orderBy_" + orderBy, CacheDuration, DataCache.ModuleControlsCachePriority, numberOfResults, orderBy), GetTopModulesCallback);
            }

            return GetTopModulesResults(numberOfResults, orderBy);
        }

        public List<PackageInfo> GetTopModulesResults(int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetTopModules?numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = Referer;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    var jObject = JObject.Parse(responseText);
                    var packages = jObject["Packages"].ToArray();

                    foreach (var package in packages)
                    {
                        var packageObj = new PackageInfo(package);
                        results.Add(packageObj);
                    }
                }
            }
            catch
            {
            }

            return results;
        }

        private object GetTopSkinsCallback(CacheItemArgs cacheItemArgs)
        {
            var numberOfResults = (int)cacheItemArgs.ParamList[0];
            var orderBy = (string)cacheItemArgs.ParamList[1];

            return GetTopSkinsResults(numberOfResults, orderBy);
        }

        public List<PackageInfo> GetTopSkins(int numberOfResults, string orderBy)
        {
            if (EnableCache)
            {
                return CBO.GetCachedObject<List<PackageInfo>>(new CacheItemArgs("DNNReferralModule_GetTopSkins_results_" + numberOfResults + "_orderBy_" + orderBy, CacheDuration, DataCache.ModuleControlsCachePriority, numberOfResults, orderBy), GetTopSkinsCallback);
            }

            return GetTopSkinsResults(numberOfResults, orderBy);
        }

        public List<PackageInfo> GetTopSkinsResults(int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetTopSkins?numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = Referer;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    var jObject = JObject.Parse(responseText);
                    var packages = jObject["Packages"].ToArray();

                    foreach (var package in packages)
                    {
                        var packageObj = new PackageInfo(package);
                        results.Add(packageObj);
                    }
                }
            }
            catch
            {
            }

            return results;
        }

        private object GetVendorsProductsCallback(CacheItemArgs cacheItemArgs)
        {
            var vendorId = (int)cacheItemArgs.ParamList[0];
            var numberOfResults = (int)cacheItemArgs.ParamList[1];
            var orderBy = (string)cacheItemArgs.ParamList[2];

            return GetVendorsProductsResults(vendorId, numberOfResults, orderBy);
        }

        public List<PackageInfo> GetVendorsProducts(int vendorId, int numberOfResults, string orderBy)
        {
            if (EnableCache)
            {
                return CBO.GetCachedObject<List<PackageInfo>>(new CacheItemArgs("DNNReferralModule_GetVendorsProducts_vendorId_" + vendorId + "_results_" + numberOfResults + "_orderBy_" + orderBy, CacheDuration, DataCache.ModuleControlsCachePriority, vendorId, numberOfResults, orderBy), GetVendorsProductsCallback);
            }

            return GetVendorsProductsResults(vendorId, numberOfResults, orderBy);
        }

        public List<PackageInfo> GetVendorsProductsResults(int vendorId, int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest =
                    (HttpWebRequest)
                    WebRequest.Create(
                        "http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetVendorsActiveProducts?vendorId=" +
                        vendorId + "&numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = Referer;

                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    var jObject = JObject.Parse(responseText);
                    var packages = jObject["Packages"].ToArray();

                    foreach (var package in packages)
                    {
                        var packageObj = new PackageInfo(package);
                        results.Add(packageObj);
                    }
                }
            }
            catch
            {
            }

            return results;
        }

        private object GetProductsBySearchCallback(CacheItemArgs cacheItemArgs)
        {
            var searchText = (string)cacheItemArgs.ParamList[0];
            var numberOfResults = (int)cacheItemArgs.ParamList[1];
            var orderBy = (string)cacheItemArgs.ParamList[2];

            return GetProductsBySearchResults(searchText, numberOfResults, orderBy);
        }

        public List<PackageInfo> GetProductsBySearch(string searchText, int numberOfResults, string orderBy)
        {
            if (EnableCache)
            {
                return CBO.GetCachedObject<List<PackageInfo>>(new CacheItemArgs("DNNReferralModule_GetVendorsProducts_searchText_" + searchText + "_results_" + numberOfResults + "_orderBy_" + orderBy, CacheDuration, DataCache.ModuleControlsCachePriority, searchText, numberOfResults, orderBy), GetProductsBySearchCallback);
            }

            return GetProductsBySearchResults(searchText, numberOfResults, orderBy);
        }

        public List<PackageInfo> GetProductsBySearchResults(string searchText, int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetProductsBySearch?searchText=" + searchText + "&numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = Referer;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    var jObject = JObject.Parse(responseText);
                    var packages = jObject["Packages"].ToArray();

                    foreach (var package in packages)
                    {
                        var packageObj = new PackageInfo(package);
                        results.Add(packageObj);
                    }
                }
            }
            catch
            {
            }

            return results;
        }
    }
}