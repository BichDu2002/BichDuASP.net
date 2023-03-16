using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication1.Context;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities1 objwebbanhangEntities1 = new webbanhangEntities1();

        // GET: Product
        public ActionResult Detail()
        {
            Product objProduct = objwebbanhangEntities1.Products.FirstOrDefault();

            return View(objProduct);
        }
    }
}