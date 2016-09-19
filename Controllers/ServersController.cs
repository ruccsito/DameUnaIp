using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DameUnaIP.Controllers
{
    public class ServersController : Controller
    {
        // GET: Servers
        public ActionResult Index()
        {
            ViewBag.Title = "Servers";
            return View();
        }
    }
}