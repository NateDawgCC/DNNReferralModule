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
using Newtonsoft.Json.Linq;

namespace DotNetNuke.Modules.DNNReferralModule.Components
{
    public class ServiceController
    {
        public static List<PackageInfo> GetTopModules(int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetTopModules?numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";

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

        public static List<PackageInfo> GetTopSkins(int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetTopSkins?numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";

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

        public static List<PackageInfo> GetVendorsProducts(int vendorId, int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetVendorsActiveProducts?vendorId=" + vendorId + "&numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";

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

        public static List<PackageInfo> GetProductsBySearch(string searchText, int numberOfResults, string orderBy)
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetProductsBySearch?searchText=" + searchText + "&numberOfResults=" + numberOfResults + "&orderBy=" + orderBy);
                httpWebRequest.Method = "GET";

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

        public static List<PackageInfo> Test()
        {
            var results = new List<PackageInfo>();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://store.dnnsoftware.com/DesktopModules/WebServices/API/APIService/GetVendorsActiveProducts?vendorId=680&numberOfResults=10&orderBy=none");
                httpWebRequest.Method = "GET";

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