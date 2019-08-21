using Sitecore.XA.Foundation.IoC;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.Variants.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.IconFilter.Abstractions
{
    public interface IIconFilterRepository : IModelRepository, IControllerRepository, IAbstractRepository<IRenderingModelBase>
        //,/*IAbstractVariantsRepository*/
    {
    }
}
