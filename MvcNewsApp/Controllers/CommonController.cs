using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNewsApp.Models.Common;

namespace MvcNewsApp.Controllers
{
    /// <summary>
    /// This controller tests how non-Sitecore MVC works within Sitecore
    /// </summary>
    public class CommonController : Controller
    {
        [HttpGet]
        public ActionResult SubmitEmail()
        {
            return View("~/Views/MvcNewsApp/Common/SubmitEmail.cshtml");
        }

        [HttpPost]
        public ActionResult SubmitEmail(SubmitEmailModel data)
        {
            return View("~/Views/MvcNewsApp/Common/SubmitEmailComplete.cshtml", data);
        }
    }
}
