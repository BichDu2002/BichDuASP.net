using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: Cart
        public ActionResult Cart()
        {
            return View((List<CartModel>)Session["cart"]);
        }

        public ActionResult AddToCart(int id, int Quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objwebbanhangEntities.Products.Find(id), Quantity = Quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantity += Quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { Product = objwebbanhangEntities.Products.Find(id), Quantity = Quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thêm thành công", JsonRequestBehavior.AllowGet });
        }
        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.id.Equals(id))
                    return i;
            return -1;
        }
        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.id == id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Xóa thành công", JsonRequestBehavior.AllowGet });
        }

    }
}