using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DameUnaIP.Models;

namespace DameUnaIP.Controllers
{
    public class BaseController : Controller
    {
        public ServerDBContext db = new ServerDBContext();
    }
}