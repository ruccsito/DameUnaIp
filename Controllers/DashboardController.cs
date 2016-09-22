using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DameUnaIP.Models;

namespace DameUnaIP.Controllers
{
    public class DashboardController : Controller
    {
        private ServerDBContext db = new ServerDBContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            DashboardModel DashData = new DashboardModel();

            DashData.TapelessCount = (from s in db.Servers where s.IpAddr.vlanId == 1 select s).Count();
            DashData.BroadcastCount = (from s in db.Servers where s.IpAddr.vlanId == 2 select s).Count();
            DashData.DmzCount = (from s in db.Servers where s.IpAddr.vlanId == 4 || s.IpAddr.vlanId == 5 select s).Count();
            DashData.MgmtCount = (from s in db.Servers where s.IpAddr.vlanId == 3 select s).Count();

            return View(DashData);
        }
    }
}