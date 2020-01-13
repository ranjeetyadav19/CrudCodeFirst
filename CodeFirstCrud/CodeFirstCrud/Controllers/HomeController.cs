using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstCrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<DataList> list = new List<DataList>();
            return View(list);
        }

    }
}