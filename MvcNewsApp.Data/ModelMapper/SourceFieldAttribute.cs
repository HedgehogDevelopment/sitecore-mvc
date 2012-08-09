using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcNewsApp.Data.ModelMapper
{
    /// <summary>
    /// Used to tell the PageEditor where to get the base value of a field
    /// </summary>
    public class SourceFieldAttribute : Attribute
    {
        public string SourceFieldName { get; set; }

        public SourceFieldAttribute(string sourceFieldName)
        {
            SourceFieldName = sourceFieldName;
        }
    }
}
