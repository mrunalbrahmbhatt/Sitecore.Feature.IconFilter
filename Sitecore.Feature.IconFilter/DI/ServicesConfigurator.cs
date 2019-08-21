using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Feature.IconFilter.Abstractions;
using Sitecore.Feature.IconFilter.Controllers;
using Sitecore.Feature.IconFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.IconFilter.DI
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IIconFilterRepository), typeof(IconFilterRepository));
            serviceCollection.AddTransient(typeof(IconFilterController));
        }
    }
}