using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    [Table("Os")]
    public class OsModel
    {
        public int id { get; set; }
        public string OsName { get; set; }
        public string Family { get; set; }
    }
}