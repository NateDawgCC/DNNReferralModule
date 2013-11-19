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
using Newtonsoft.Json.Linq;

namespace DotNetNuke.Modules.DNNReferralModule.Components
{
    public class ReviewInfo
    {
        public ReviewInfo(JToken jReview)
        {
            ReviewId = (int)jReview["id"];
            PackageName = (string)jReview["packageName"];
            PackageLink = (string)jReview["packageURL"];
            PackageIcon = (string)jReview["packageIcon"];
            Rating = (double)jReview["rating"];
            Review = (string)jReview["review"];
            ReviewerName = (string)jReview["reviewerName"];
            ReviewerLink = (string)jReview["reviewerLink"];
            Reply = (string)jReview["reply"];
            Date = (DateTime)jReview["date"];
            RatingImage = (string)jReview["ratingImage"];
            VendorName = (string)jReview["vendorName"];
            VendorLink = (string)jReview["vendorLink"];
        }

        public int ReviewId { get; set; }
        public string PackageName { get; set; }
        public string PackageLink { get; set; }
        public string PackagePrice { get; set; }
        public string PackageIcon { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerLink { get; set; }
        public string Reply { get; set; }
        public DateTime Date { get; set; }
        public string RatingImage { get; set; }
        public string VendorName { get; set; }
        public string VendorLink { get; set; }
    }
}