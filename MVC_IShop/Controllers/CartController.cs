using MVC_IShop.Models;
using ShopDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_IShop.Controllers
{
    public class CartController : Controller
    {
        GoodContext db = new GoodContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        public ActionResult AddToCart(int id)
        {
            var cartItem = db.Carts.SingleOrDefault(s => s.GoodId == id);

            if(cartItem == null)
            {
                cartItem = new Cart
                {
                    GoodId = id,
                    Count = 1,
                    DateCreate = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Goods");
        }

        [HttpGet]
        public ActionResult GoodDeleteCart(int id)
        {
            ViewBag.Name = db.Carts.First(x => x.GoodId == id).Good.GoodName + "(позициия № " + db.Carts.First(x => x.GoodId == id).RecordId + ')';
            return PartialView();
        }

        [HttpPost]
        [ActionName("GoodDeleteCart")]
        public async Task<ActionResult> GoodDeleteConfirmed(int id)
        {
            try
            {
                Cart tmp = await db.Carts.FindAsync(id);
                if (tmp != null)
                {
                    db.Carts.Remove(tmp);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Cart");
                }
            }
            catch { }

            return RedirectToAction("Index", "Cart");
        }
    }
}