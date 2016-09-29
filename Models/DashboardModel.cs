using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    [Table("Dashboard")]
    public class DashboardModel
    {
        public int TapelessCount { get; set; }
        public int TapelessId { get; set; }
        public int BroadcastCount { get; set; }
        public int BroadcasId { get; set; }

        public int DmzCount { get; set; }
        public int DmzId { get; set; }

        public int MgmtCount { get; set; }
        public int MgmtId { get; set; }

    }
}