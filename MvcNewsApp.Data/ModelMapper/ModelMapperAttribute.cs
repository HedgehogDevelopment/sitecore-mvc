using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcNewsApp.Data.ModelMapper
{
    /// <summary>
    /// Used to tell the ModelFactory that the class(Model) is mapped to a Sitecore Template.
    /// </summary>
    public class ModelMapperAttribute : Attribute
    {
        public Guid TemplateId { get; set; }

        public ModelMapperAttribute(string templateIdString)
        {
            TemplateId = Guid.Parse(templateIdString);
        }
    }
}
