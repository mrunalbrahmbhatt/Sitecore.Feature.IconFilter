using Sitecore.XA.Feature.Search.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.IconFilter.Model
{
    public class IconFilterRenderingModel : FacetRenderingModel
    {
        public string FilterButtonLabel
        {
            get;
            set;
        }

        public bool MultiSelection
        {
            get;
            set;
        }
        public HtmlString Html { get; set; }
    }
}