using Sitecore.Feature.IconFilter.Abstractions;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.IconFilter.Controllers
{
    public class IconFilterController :  StandardController
    {
        protected IIconFilterRepository IconFilterRepository
        {
            get;
            set;
        }

        //public IconFilterController()
        //{

        //}
        public IconFilterController(IIconFilterRepository iconFilterRepository)
        {
            IconFilterRepository = iconFilterRepository;
        }

        // GET: IconFilter
        protected override object GetModel()
        {
            return IconFilterRepository.GetModel();
        }
    }
}