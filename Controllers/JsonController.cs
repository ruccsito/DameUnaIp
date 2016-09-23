using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DameUnaIP.Models;
using System.Net;
using System.Net.NetworkInformation;

namespace DameUnaIP.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json for IPs
        public ActionResult IPs(int id, DataTablesModel param)
        {
            ServerDBContext db = new ServerDBContext();

            var query = (from i in db.IpAddrs where i.vlanId == id select i).ToArray();

            IEnumerable<string[]> results;

            if (string.IsNullOrEmpty(param.sSearch))
            {
                results = (from i in query
                           where i.vlanId == id
                           select new[] { i.Addr, i.InUse.ToString(), i.Vlans.Name, "<a href=\"/json/Pinguear/" + i.id + "\">Pingueala! </a>" })
                          .Skip(param.iDisplayStart)
                          .Take(param.iDisplayLength);
            }

            else
            {
                results = (from i in query
                           where i.vlanId == id && i.Addr.Contains(param.sSearch) 
                           select new[] { i.Addr, i.InUse.ToString(), i.Vlans.Name, "<a href=\"/json/Pinguear/" + i.id + "\">Pingueala! </a>" })
                          .Skip(param.iDisplayStart)
                          .Take(param.iDisplayLength);
            }

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = query.Count(),
                aaData = results
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Json for Servers
        public ActionResult Servers(DataTablesModel param)
        {
            ServerDBContext db = new ServerDBContext();

            var query = (from s in db.Servers select s).ToArray();

            IEnumerable<string[]> results;

            if (string.IsNullOrEmpty(param.sSearch))
            {
                results = (from s in query
                           select new[] { s.Name, s.IpAddr.Addr, s.Os.OsName, s.Created.Date.ToShortDateString(), "<a href=\"/Servers/Edit/" + s.id + "\"> Edit! </a>" })
                          .Skip(param.iDisplayStart)
                          .Take(param.iDisplayLength);
            }

            else
            {
                
                results = (from s in query
                           where s.Name.ToLower().Contains(param.sSearch.ToLower()) || s.IpAddr.Addr.Contains(param.sSearch)
                           select new[] { s.Name, s.IpAddr.Addr, s.Os.OsName, s.Created.Date.ToShortDateString(), "<a href=\"/Servers/Edit/" + s.id + "\"> Edit! </a>" })
                          .Skip(param.iDisplayStart)
                          .Take(param.iDisplayLength);
            }

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = query.Count(),
                aaData = results
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Pinguear(int id)
        {

            ServerDBContext db = new ServerDBContext();

            var ip = db.IpAddrs.First(i => i.id == id);

            Ping myPing = new Ping();
            PingReply myPingReply = myPing.Send(ip.Addr);

            string response;

            if (myPingReply.Status == IPStatus.Success)
            {
                response = ip.Addr + " Pinguea ameoo";
            }

            else
            {
                response = ip.Addr + " No andaaa";
            }

            return Content(response);
        }
    }
}