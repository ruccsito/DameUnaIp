using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    public class DashboardModel
    {
        public int TapelessCount { get; set; }
        public int BroadcastCount { get; set; }
        public int DmzCount { get; set; }
        public int MgmtCount { get; set; }
    }
}