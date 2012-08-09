using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Reflection;

namespace MvcNewsApp.Data.ModelMapper
{
    public static class ModelFactory
    {
        static Lazy<Dictionary<Guid, Type>> _templateModelMap = new Lazy<Dictionary<Guid,Type>>(() =>
        {
            return InitModelMap();
        });

        /// <summary>
        /// Returns an enumeration of newly created models from an array of Sitecore items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> Models<T>(Item[] items) where T : class
        {
            //Loop through the array and create models
            foreach (Item item in items)
            {
                T model = Model<T>(item, true);

                if (model != null)
                {
                    //Don't return items that have no Model
                    yield return model;
                }
            }
        }

        /// <summary>
        /// Returns an enumeration of newly created models from an enumeration of items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> Models<T>(IEnumerable<Item> items) where T : class
        {
            //Loop through the enumeration and create models
            foreach (Item item in items)
            {
                T model = Model<T>(item, true);

                if (model != null)
                {
                    //Don't return items that have no Model
                    yield return model;
                }
            }
        }

        /// <summary>
        /// Returns a newly created model from a Sitecore item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">Item to use as the datasource for the model</param>
        /// <param name="initializeModel">If true, the model will be initialized.</param>
        /// <returns></returns>
        public static T Model<T>(Item item, bool initializeModel) where T : class
        {
            // See if there is a mapping
            if (!_templateModelMap.Value.ContainsKey(item.TemplateID.Guid))
            {
                throw new InvalidOperationException(string.Format("Cannot create a model for item {0} because template {1} doesn't have a model", item.Paths.FullPath, item.TemplateName));
            }

            //Get the C# type of the items template
            Type typeToCreate = _templateModelMap.Value[item.TemplateID.Guid];

            //Create it
            T obj = typeToCreate.Assembly.CreateInstance(typeToCreate.FullName) as T;

            //Try to initialize it
            IRenderingModel renderingModel = obj as IRenderingModel;

            if (renderingModel != null && initializeModel)
            {
                //Initialize it.
                renderingModel.Initialize(new Rendering
                {
                    Item = item
                });
            }

            return obj;
        }

        /// <summary>
        /// Initializes the model mapper
        /// </summary>
        /// <returns></returns>
        private static Dictionary<Guid, Type> InitModelMap()
        {
            Dictionary<Guid, Type> retVal = new Dictionary<Guid, Type>();

            //Finds all types in the current assembly. This is ok since this is only a POC
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                //See if the class has a mapping attribute
                ModelMapperAttribute attribute = type.GetCustomAttributes(typeof(ModelMapperAttribute), false).FirstOrDefault() as ModelMapperAttribute;

                if (attribute != null)
                {
                    //Add it to the map
                    retVal.Add(((ModelMapperAttribute)attribute).TemplateId, type);
                }
            }

            return retVal;
        }
    }
}
