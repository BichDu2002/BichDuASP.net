using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class CatagoryController : Controller
    {
        webbanhangEntities1 objwebbanhangEntities1 = new webbanhangEntities1();
        // GET: Catagory
        public ActionResult Catagory()
        {
            var lstCatagory= objwebbanhangEntities1.Categories.ToList();
            return View(lstCatagory);
        }
        public ActionResult ProductCatagory()
        {
            var lstProduct=objwebbanhangEntities1.Products.ToList();
            return View(lstProduct);
        }
    }
}