using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    public class IpAddrModel
    {
        public int id { get; set; }

        [DisplayName("IP Address")]
        public string Addr { get; set; }

        [DisplayName("In Use")]
        public bool InUse { get; set; }

        [ForeignKey("Vlans")]
        public int vlanId { get; set; }

        [DisplayName("vLan")]
        public virtual VlansModel Vlans { get; set; }
    }
}