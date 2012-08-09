using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcNewsApp.Data.Entities.Interfaces
{
    public partial interface INavigable
    {
        string PageTitle { get; }
    }
}
