
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using static WebApplication1.Common;

namespace WebApplication1.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities dbObj = new webbanhangEntities();

        // GET: admin/Product
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
                lstProduct = dbObj.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = dbObj.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();

            return View();


        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();

            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    objProduct.CreatedOnUct = DateTime.Now;
                    dbObj.Products.Add(objProduct);
                    dbObj.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception)

                {
                    return RedirectToAction("Index");
                }
            }

            return View(objProduct);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
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
            this.LoadData();
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();

            return View(objProduct);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                }
                objProduct.UpdatedOnUct = DateTime.Now;
                dbObj.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
                dbObj.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(objProduct);
        }

        void LoadData()
        {
            Common objCommon = new Common();
            //lây dữ liệu db

            var lstCat = dbObj.Categories.ToList();
            //conver sang select
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);

            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "id", "Name");
            //lấy dữ liệu thuowg hiêu

            var lstBrand = dbObj.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //convert sang select

            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "id", "Name");

            List<ProductTypeId> lstProductType = new List<ProductTypeId>();

            ProductTypeId objProductType = new ProductTypeId();
            objProductType.Id = 1;
            objProductType.Name = "Giảm giá sốc";

            lstProductType.Add(objProductType);

            objProductType = new ProductTypeId();
            objProductType.Id = 2;
            objProductType.Name = "Đề xuất";

            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);

            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "id", "Name");
        }
    
    }
}