using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tholumuntu.Controllers
{
    public class FindLoveController : Controller
    {
        // GET: FindLove
        public ActionResult Index()
        {
            ViewBag.FullName = Session["FullName"];

            return View();
        }
    }
}