using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Feature.IconFilter.Abstractions;
using Sitecore.Feature.IconFilter.Model;
using Sitecore.XA.Feature.Search.Repositories;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Fields;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Renderers;
using Sitecore.XA.Foundation.Variants.Abstractions.Repositories;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Sitecore.Feature.IconFilter.Repository
{
    public class IconFilterRepository : FacetModelRepository, IIconFilterRepository
    {

        #region Rendering Variant
        private Item _variantItem;
        private List<BaseVariantField> _variantFields;
        protected IVariantFieldParser FieldParser;
        private readonly IAvailableRenderingVariantService AvailableRenderingVariantService;
        private readonly IVariantRenderer VariantRenderer;
        protected Item CurrentItem => PageContext.Current;

        public virtual Item VariantItem
        {
            get
            {
                if (_variantItem == null)
                {
                    string id = Rendering.Parameters["FieldNames"];
                    if (ID.IsID(id))
                    {
                        _variantItem = ContentRepository.GetItem(new ID(id));
                    }
                    _variantItem = (_variantItem ?? GetFirstAvailableComponentVariant());
                }
                return _variantItem;
            }
        }

        protected virtual bool MultiSelection => Rendering.Parameters["MultiSelection"] == "1";
        protected virtual Item GetFirstAvailableComponentVariant()
        {
            return AvailableRenderingVariantService.GetAvailableRenderingVariants(CurrentItem, Rendering.Name, Rendering.RenderingId, PageContext.Current.TemplateID.ToString()).FirstOrDefault();
        }
        #endregion
        public IconFilterRepository(IVariantFieldParser fieldParser, IVariantRenderer variantRenderer, IAvailableRenderingVariantService availableRenderingVariantService)
        {
            FieldParser = fieldParser;
            VariantRenderer = variantRenderer;
            AvailableRenderingVariantService = availableRenderingVariantService;
        }


        protected virtual string EmptyValueText
        {
            get
            {
                if (Rendering.DataSourceItem == null)
                {
                    return string.Empty;
                }
                return Rendering.DataSourceItem["EmptyValueText"];
            }
        }

        protected override string JsonDataProperties
        {
            get
            {
                var obj = new
                {
                    endpoint = HomeUrl + "/sxa/search/facets/",
                    f = FacetItemName,
                    searchResultsSignature = SearchResultsSignature,
                    emptyValueText = EmptyValueText,
                    multi = MultiSelection,
                    sortOrder = Rendering.Parameters["SortOrder"],

                };
                return new JavaScriptSerializer().Serialize(obj);
            }
        }

        public virtual string GetRenderingVariantHtml()
        {
            VariantRenderer.SetParams(new RendererParameters
            {
                IsControlEditable = false,
                RendererMode = RendererMode.Html
            });
            return VariantRenderer.RenderVariant(VariantItem, Rendering.DataSourceItem);
        }
        public override IRenderingModelBase GetModel()
        {
            IconFilterRenderingModel model = new IconFilterRenderingModel();
            FillBaseProperties(model);
            model.JsonDataProperties = JsonDataProperties;
            model.Html = new HtmlString(GetRenderingVariantHtml());
            return model;
        }

        protected override void FillBaseProperties(object m)
        {
            base.FillBaseProperties(m);
        }
    }
}