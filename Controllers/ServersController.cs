using DameUnaIP.Models;
using DameUnaIP.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DameUnaIP.Controllers
{
    public class ServersController : Controller
    {
        private ServerDBContext db = new ServerDBContext();

        // GET: Servers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var FreeIps = (from i in db.IpAddrs
                           where i.InUse == false
                           orderby i.Addr
                           select new { i.id, i.Addr }).Skip(10).Take(5);

            ViewBag.IpAddrId = new SelectList(FreeIps, "id", "Addr");
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewServer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,IpAddrId,OsId")] NewServerModel NewServer)
        {
            if (ModelState.IsValid)
            {
                ServersModel server = new ServersModel();

                server.Name = NewServer.Name;
                server.IpAddrId = NewServer.IpAddrId;
                server.OsId = NewServer.OsId;
                server.Created = DateTime.Now;

                IpAddrModel Ip = db.IpAddrs.Single(i => i.id == NewServer.IpAddrId);
                Ip.InUse = true;

                db.Servers.Add(server);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IpAddrId = new SelectList(db.IpAddrs, "id", "Addr", NewServer.IpAddrId);
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName", NewServer.OsId);
            return View(NewServer);
        }
    }
}