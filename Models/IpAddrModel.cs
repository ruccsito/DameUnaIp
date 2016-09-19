using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    public class IpAddrModel
    {
        public int id { get; set; }
        public string Addr { get; set; }
        public bool InUse { get; set; }

        [ForeignKey("Vlans")]
        public int vlanId { get; set; }

        public virtual VlansModel Vlans { get; set; }
    }
}