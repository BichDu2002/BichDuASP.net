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
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        // GET: Product
        public ActionResult Detail(int id)
        {
            Product objProduct = objwebbanhangEntities.Products.Where(n=>n.id==id).FirstOrDefault();

            return View(objProduct);
        }
    }
}