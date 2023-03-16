using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities1 dbObj = new webbanhangEntities1();

        // GET: admin/Product
        public ActionResult Index()
        {
            // GET: admin/Home

            var lstProduct = dbObj.Products.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if(objProduct.ImageUpload !=null)
                {
                    string fileName= Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension= Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("fghgzdjfghjghxf"));
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"),fileName));
                }
                dbObj.Products.Add(objProduct);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception )
            
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Details(int id) 
        { 
        var objProduct = dbObj.Products.Where(n=>n.id==id).FirstOrDefault();
            return View(objProduct);
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);

        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            
            var objProduct = dbObj.Products.Where(n => n.id == objPro.id).FirstOrDefault();
            dbObj.Products.Remove(objProduct);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var objProduct = dbObj.Products.Where(n => n.id ==id).FirstOrDefault();

            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit(int id,Product objProduct)
        {
            if(objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("fghgzdjfghjghxf"));
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
            }
            dbObj.Entry(objProduct).State=EntityState.Modified;
            dbObj.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}