using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackMainController : Controller
    {
        // GET: BackMain
        public ActionResult Index()
        {
            return View();
        }
    }
}