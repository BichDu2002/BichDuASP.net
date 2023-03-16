using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Listing()
        {
            return View();
        }
    }
}