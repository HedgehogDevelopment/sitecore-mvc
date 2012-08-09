using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcNewsApp.Data.Entities.Interfaces;

namespace MvcNewsApp.Data.Entities
{
    public partial class Page : INavigable
    {
        public string PageTitle
        {
            get
            {
                if (string.IsNullOrEmpty(NavigationTitle))
                {
                    if (string.IsNullOrEmpty(Title))
                    {
                        return SitecoreItem.Name;

                    }
                    else
                    {
                        return Title;
                    }
                }
                else
                {
                    return NavigationTitle;
                }
            }
        }
    }
}
