using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.admin.Controllers
{
    public class BrandController : Controller
    {
        webbanhangEntities dbObj = new webbanhangEntities();
        // GET: admin/Brand
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Brand>();
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
                lstProduct = dbObj.Brands.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = dbObj.Brands.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = dbObj.Brands.Where(n => n.id == id).FirstOrDefault();
            return View(objBrand);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = dbObj.Brands.Where(n => n.id == id).FirstOrDefault();
            return View(objBrand);

        }
        [HttpPost]
        public ActionResult Delete(Brand objPro)
        {

            var objBrand = dbObj.Brands.Where(n => n.id == objPro.id).FirstOrDefault();
            dbObj.Brands.Remove(objBrand);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var objPrand = dbObj.Brands.Where(n => n.id == id).FirstOrDefault();

            return View(objPrand);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (ModelState.IsValid)
            {
                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                }
                objBrand.UpdatedOnUct = DateTime.Now;
                dbObj.Entry(objBrand).State = System.Data.Entity.EntityState.Modified;
                dbObj.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(objBrand);
        }

        [HttpGet]
        public ActionResult Create()
        {
            

            return View();


        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    objBrand.CreatedOnUct = DateTime.Now;
                    dbObj.Brands.Add(objBrand);
                    dbObj.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception)

                {
                    return RedirectToAction("Index");
                }
            }

            return View(objBrand);
        }

    }
}