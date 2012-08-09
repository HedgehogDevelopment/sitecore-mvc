using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcNewsApp.Data.ModelMapper;

namespace MvcNewsApp.Data.Entities
{
    /// <summary>
    /// Partial class to show how to add additional functionality to the models
    /// </summary>
    public partial class Article
    {
        /// <summary>
        /// Creates a formatted date for the article date
        /// </summary>
        [SourceField("ArticleDate")]
        public string FormattedArticleDate
        {
            get
            {
                return ArticleDate.DateTime.ToLongDateString();
            }
        }
    }
}
