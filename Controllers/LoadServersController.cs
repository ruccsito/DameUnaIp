using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DameUnaIP.Models;
using DameUnaIP.Tools;

namespace DameUnaIP.Controllers
{
    public class LoadServersController : BaseController
    {
        // GET: LoadServers
        public ActionResult Start()
        {
            string csv = @"C:\Users\julioar\Desktop\latest_broadcast.csv";
            string[] lines = System.IO.File.ReadAllLines(csv);

            List<ServersModel> list = new List<ServersModel>();

            foreach (var line in lines)
            {
                string[] spline = line.Split(';');

                ServersModel server = new ServersModel
                {
                    Name = spline[0],
                    OsId = Int32.Parse(spline[1]),
                    IpAddrId = Tools.Tools.FindIdByAddr(spline[2]),
                    Created = DateTime.Now
                };
                list.Add(server);
            }

            using (db) {
                foreach (var server in list)
                {
                    db.Servers.Add(server);
                    db.IpAddrs.First(ip => ip.id == server.IpAddrId).InUse = true;
                }
                db.SaveChanges();
            }

            return View(list);
        }
    }
}