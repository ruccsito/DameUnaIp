using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DameUnaIP.Models
{
    [Table("Vlans")]
    public class VlansModel
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}