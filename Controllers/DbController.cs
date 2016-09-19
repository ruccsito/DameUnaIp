using DameUnaIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace DameUnaIP.Controllers
{
    public class DbController : Controller
    {
        // GET: Db
        public ActionResult Index()
        {
            return Content("Hola :)");
        }

        // Crear cosas en la DB.
        public ActionResult UpdateByPing()
        {
            ServerDBContext db = new ServerDBContext();

            var AllIps = from i in db.IpAddrs
                         select i;

            Ping myPing = new Ping();
            
            foreach (var i in AllIps)
            {
                PingReply myPingReply = myPing.Send(i.Addr);

                if (myPingReply.Status == IPStatus.Success)
                {
                    // Updatear la DB para marcar como inUse.
                }
            }

            return Content(":D");
        }

        public ActionResult CreateBase()
        {
            ServerDBContext db = new ServerDBContext();

            //Initial Load
            db.Vlans.Add(new VlansModel { Name = "Tapeless" });
            db.Vlans.Add(new VlansModel { Name = "Broadcast" });
            db.Vlans.Add(new VlansModel { Name = "Managment" });
            db.Vlans.Add(new VlansModel { Name = "Private DMZ" });
            db.Vlans.Add(new VlansModel { Name = "Public DMZ" });

            db.Os.Add(new OsModel { OsName = "Centos 7", Family = "Unix" });
            db.Os.Add(new OsModel { OsName = "SLES 11", Family = "Unix" });
            db.Os.Add(new OsModel { OsName = "Ubuntu 14", Family = "Unix" });

            db.Os.Add(new OsModel { OsName = "Windows 2008", Family = "Windows" });
            db.Os.Add(new OsModel { OsName = "Windows 2012", Family = "Windows" });
            db.Os.Add(new OsModel { OsName = "Windows 7", Family = "Windows" });

            db.SaveChanges();

            for (int i = 1; i < 255; i++)
            {
                db.IpAddrs.Add(new IpAddrModel { Addr = "10.221.173." + i, InUse = false, vlanId = 1 });
            }

            for (int i = 1; i < 255; i++)
            {
                db.IpAddrs.Add(new IpAddrModel { Addr = "10.220.216." + i, InUse = false, vlanId = 2 });
            }

            for (int i = 1; i < 255; i++)
            {
                db.IpAddrs.Add(new IpAddrModel { Addr = "10.220.217." + i, InUse = false, vlanId = 3 });
            }

            db.SaveChanges();


            return Content("Done!");
        }

        public ActionResult CreateServers()
        {
            ServerDBContext db = new ServerDBContext();

            Random rnd = new Random();

            for (int i = 0; i < 40; i++)
            {
                ServersModel srv = new ServersModel()
                {
                    Name = "FNGARBASRV" + rnd.Next(1000, 2000).ToString(),
                    OsId = rnd.Next(1, 6),
                    Created = DateTime.Now,
                    IpAddrId = rnd.Next(1527, 2288)
                };
                db.Servers.Add(srv);
            }

            db.SaveChanges();

            return Content("Ok.. ");
        }
    }
}