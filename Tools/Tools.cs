using DameUnaIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DameUnaIP.Tools
{
    public class Tools
    {

        public static int FindIdByAddr(string addr)
        {
            using (ServerDBContext db = new ServerDBContext()) {
                int id = db.IpAddrs.First(i => i.Addr == addr).id;
                return (id);
            }
        }
    }
}