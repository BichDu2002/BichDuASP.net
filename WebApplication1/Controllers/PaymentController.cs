using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PaymentController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: Payment
        public ActionResult Index()
        {
          
                if (Session["idUser"] == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    var lstCart = (List<CartModel>)Session["cart"];
                    Order objOrder = new Order();
                    objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    objOrder.Userld = int.Parse(Session["idUser"].ToString());
                    objOrder.CreatedOnUct = DateTime.Now;
                    objOrder.Status = 1;
                    objwebbanhangEntities.Orders.Add(objOrder);
                    objwebbanhangEntities.SaveChanges();
                    int intOrderId = objOrder.id;

                    List<OrderDetail> lstOrderDetail = new List<OrderDetail>();

                    foreach (var item in lstCart)
                    {
                        OrderDetail obj = new OrderDetail();
                        obj.Orderld = intOrderId;
                        obj.Quantity = item.Quantity;
                        obj.Productld = item.Product.id;
                        lstOrderDetail.Add(obj);
                    }
                    objwebbanhangEntities.OrderDetails.AddRange(lstOrderDetail);
                    objwebbanhangEntities.SaveChanges();
                }

                return View();
              }
    }
}