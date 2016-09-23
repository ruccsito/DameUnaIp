using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    [Table("Servers")]
    public class ServersModel
    {
        public int id { get; set; }
        [DisplayName("Server Name")]
        public string Name { get; set; }
        [DisplayName("Creation Date")]
        public DateTime Created { get; set; }

        [ForeignKey("IpAddr")]
        [DisplayName("IP Address")]
        public int IpAddrId { get; set; }
        public virtual IpAddrModel IpAddr { get; set; }

        [ForeignKey("Os")]
        [DisplayName("Server OS")]
        public int OsId { get; set; }
        public virtual OsModel Os { get; set; }
    }
}