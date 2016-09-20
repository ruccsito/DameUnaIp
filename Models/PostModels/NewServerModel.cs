using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models.PostModels
{
    public class NewServerModel
    {
        public string Name { get; set; }
        public int IpAddrId { get; set; }
        public int OsId { get; set; }
    }
}