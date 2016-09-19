using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DameUnaIP.Models;

namespace DameUnaIP.Controllers
{
    public class SrvScaController : Controller
    {
        private ServerDBContext db = new ServerDBContext();

        // GET: Servers
        public ActionResult Index()
        {
            //var servers = db.Servers.Include(s => s.IpAddr).Include(s => s.Os);
            var servers = from s in db.Servers
                          where s.Os.OsName == "Centos 7"
                          select s;

            return View(servers.ToList());
        }

        // GET: Servers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersModel serversModel = db.Servers.Find(id);
            if (serversModel == null)
            {
                return HttpNotFound();
            }
            return View(serversModel);
        }

        // GET: Servers/Create
        public ActionResult Create()
        {
            ServerDBContext db = new ServerDBContext();

            var FreeIps = (from i in db.IpAddrs
                          where i.InUse == false
                          select new { i.id, i.Addr }).Take(5);

            //ViewBag.IpAddrId = new SelectList(db.IpAddrs, "id", "Addr");

            ViewBag.IpAddrId = new SelectList(FreeIps, "id", "Addr");
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName");
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Created,IpAddrId,OsId")] ServersModel serversModel)
        {
            if (ModelState.IsValid)
            {
                db.Servers.Add(serversModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IpAddrId = new SelectList(db.IpAddrs, "id", "Addr", serversModel.IpAddrId);
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName", serversModel.OsId);
            return View(serversModel);
        }

        // GET: Servers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersModel serversModel = db.Servers.Find(id);
            if (serversModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IpAddrId = new SelectList(db.IpAddrs, "id", "Addr", serversModel.IpAddrId);
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName", serversModel.OsId);
            return View(serversModel);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Created,IpAddrId,OsId")] ServersModel serversModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serversModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IpAddrId = new SelectList(db.IpAddrs, "id", "Addr", serversModel.IpAddrId);
            ViewBag.OsId = new SelectList(db.Os, "id", "OsName", serversModel.OsId);
            return View(serversModel);
        }

        // GET: Servers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServersModel serversModel = db.Servers.Find(id);
            if (serversModel == null)
            {
                return HttpNotFound();
            }
            return View(serversModel);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServersModel serversModel = db.Servers.Find(id);
            db.Servers.Remove(serversModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
