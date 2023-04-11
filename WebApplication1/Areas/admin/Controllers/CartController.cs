using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Controllers
{
    public class CartController : Controller
    {
        
        // GET: admin/Cart
        public ActionResult Index()
        {
            return View();
        }

        
    }

}
    
