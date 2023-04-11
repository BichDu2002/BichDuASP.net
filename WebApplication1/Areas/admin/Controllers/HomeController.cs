using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Controllers
{

    public class HomeController : Controller
    {
        webbanhangEntities dbObj = new webbanhangEntities();

        // GET: admin/Home
        public ActionResult Index()
        {

            HomeModel objHomeModel=new HomeModel();

            objHomeModel.ListCategory = dbObj.Categories.OrderByDescending(n => n.id).ToList();
            objHomeModel.ListProduct= dbObj.Products.ToList();
            return View(objHomeModel);
        }
        [HttpGet]

        public ActionResult Register()
        {


            return View();
        }
    }
}