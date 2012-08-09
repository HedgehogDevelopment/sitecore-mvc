using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Mvc.Pipelines.Response.GetModel;
using MvcNewsApp.Data.ModelMapper;
using Sitecore.Diagnostics;

namespace MvcNewsApp.Data.Pipelines
{
    /// <summary>
    /// This pipeline uses our ModelFactory to get the model for an item. It assumes that there is only one registered model for an item.
    /// This is OK because the models are created by code generation, so there should be only one.
    /// </summary>
    public class GetMappedModel : GetModelProcessor
    {
        public override void Process(GetModelArgs args)
        {
            //See if someone else chose a model
            if (args.Result == null)
            {
                args.Result = ModelFactory.Model<BaseEntity>(args.Rendering.Item, false);

                if (args.Result != null)
                {
                    Tracer.Info(string.Format("Bound model {0} to item {1}", args.Result.GetType().FullName, args.Rendering.Item.ID));
                }
            }
        }
    }
}
