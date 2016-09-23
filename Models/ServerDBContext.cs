using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    public class ServerDBContext : DbContext
    {
        public ServerDBContext() : base("SQLExpress")
        {

        }

        public DbSet<IpAddrModel> IpAddrs { get; set; }
        public DbSet<ServersModel> Servers { get; set; }
        public DbSet<VlansModel> Vlans { get; set; }
        public DbSet<OsModel> Os { get; set; }
    }
}