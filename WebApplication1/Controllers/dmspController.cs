using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class dmspController : Controller
    {


        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: dmsp
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {

            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = objwebbanhangEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = objwebbanhangEntities.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Listing(int Id)
        {
            var listProduct = objwebbanhangEntities.Products.Where(n => n.Categoryld == 1).ToList();
            return View(listProduct);
        }
    }
}