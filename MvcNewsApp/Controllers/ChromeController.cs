using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNewsApp.Data.Entities.Interfaces;
using MvcNewsApp.Models.Chrome;
using MvcNewsApp.Data;
using Sitecore.Data.Items;
using MvcNewsApp.Data.ModelMapper;

namespace MvcNewsApp.Controllers
{
    public class ChromeController : Controller
    {
        /// <summary>
        /// Handle building the Topnav data structures
        /// </summary>
        /// <returns></returns>
        public ActionResult TopNav()
        {
            TopNavModel model = new TopNavModel();

            model.Navigation = new List<INavigable>();

            Item homeItem = Sitecore.Context.Database.GetItem("/sitecore/Content/Home");
            //Add the home item
            model.Navigation.Add(ModelFactory.Model<INavigable>(homeItem, true));
            
            //Add child items
            model.Navigation.AddRange(ModelFactory.Models<INavigable>(homeItem.Children));

            return View("~/Views/MvcNewsApp/Chrome/TopNav.cshtml", model);
        }

    }
}
