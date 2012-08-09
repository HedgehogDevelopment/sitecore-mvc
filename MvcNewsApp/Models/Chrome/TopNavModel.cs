using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcNewsApp.Data.Entities.Interfaces;

namespace MvcNewsApp.Models.Chrome
{
    /// <summary>
    /// Model that holds all the INavigable items that can go in the topnav
    /// </summary>
    public class TopNavModel
    {
        public List<INavigable> Navigation { get; set; }
    }
}