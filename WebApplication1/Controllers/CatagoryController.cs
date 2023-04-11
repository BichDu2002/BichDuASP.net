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
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: Catagory
        public ActionResult Catagory()
        {
            var lstCatagory= objwebbanhangEntities.Categories.ToList();
            return View(lstCatagory);
        }
        public ActionResult ProductCatagory(int Id)
        {
            var lstProduct=objwebbanhangEntities.Products.Where(n=>n.Categoryld == Id).ToList();
            return View(lstProduct);
        }
    }
}