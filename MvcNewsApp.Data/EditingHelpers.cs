using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using Sitecore.Mvc;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;
using MvcNewsApp.Data.ModelMapper;

namespace MvcNewsApp.Data
{
    public static class EditingHelpers
    {
        /// <summary>
        /// Renders a Sitecore field. The value is rendered in run mode, the editor is rendered in PageEdit mode.
        /// If the property in the model isn't a Sitecore field, then use the SourceField attribute to find the original field.
        /// This makes the syntax for Sitecore fields a bit more compact.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static HtmlString FieldFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            //Find the SourceField attribute if there is one
            MemberExpression body = expression.Body as MemberExpression;
            SourceFieldAttribute sourceField = body.Member.GetCustomAttributes(typeof(SourceFieldAttribute), false).FirstOrDefault() as SourceFieldAttribute;

            //Get the metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData);

            //If there is no source field, then skip any special processing
            if (sourceField == null)
            {
                return html.Sitecore().Field(metadata.PropertyName);
            }
            else
            {
                //If er are editing, render the base field
                if (Sitecore.Context.PageMode.IsPageEditorEditing)
                {
                    return html.Sitecore().Field(sourceField.SourceFieldName);
                }
                else
                {
                    //Render the value
                    if (metadata.Model != null)
                    {
                        return new HtmlString(metadata.Model.ToString());
                    }
                    else
                    {
                        return new HtmlString(string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the RenderingItem from the HtmlHelper. This is purely for convience
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static Item RenderingItem(this HtmlHelper html)
        {
            return RenderingContext.Current.Rendering.Item;
        }

        /// <summary>
        /// Returns the item URL. It is purely for convience. It uses the default url options.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Url(this Item item)
        {
            return LinkManager.GetItemUrl(item);
        }
    }
}
