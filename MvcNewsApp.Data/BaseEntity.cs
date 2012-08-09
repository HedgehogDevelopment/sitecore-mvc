using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using System.Reflection;

namespace MvcNewsApp.Data
{
    /// <summary>
    /// All generated models will inherit from this base class
    /// </summary>
    public class BaseEntity : IRenderingModel, IBaseEntity
    {
        public virtual void Initialize(Rendering rendering)
        {
            SitecoreItem = rendering.Item;
        }

        /// <summary>
        /// Hold a reference to the Sitecore item. This makes it much more convient to get back to Sitecore
        /// incase we missed something in the model.
        /// </summary>
        public Item SitecoreItem { get; set; }
    }

    /// <summary>
    /// All generated interfaces will inherit from this base class
    /// </summary>
    public interface IBaseEntity
    {
        Item SitecoreItem { get; set; }
    }
}
