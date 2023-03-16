using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.admin.Controllers
{

    public class HomeController : Controller
    {
        webbanhangEntities1 dbObj = new webbanhangEntities1();

        // GET: admin/Home
        public ActionResult Index()
        {
            var lstProduct = dbObj.Products.ToList();
            return View(lstProduct);
        }
    }
}