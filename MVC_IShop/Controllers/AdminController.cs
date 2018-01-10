using MVC_IShop.Models;
using ShopDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_IShop.Controllers
{
    public class AdminController : Controller
    {
        GoodContext db = new GoodContext();
        ApplicationContext UsDB = new ApplicationContext();

        [Authorize]
        public ActionResult Index()
        {
            List<Good> goods = db.Goods.ToList();
            return View(goods.OrderBy(s=> s.GoodName));
        }

        [Authorize]
        public ActionResult AddGood()
        {
            AddGoodModel model = new AddGoodModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddGood(AddGoodModel model)
        {
            if (ModelState.IsValid)
            {
                Good good = new Good
                {
                    GoodName = model.GoodName,
                    Manufacturer = model.Manufacturer,
                    Category = model.Category,
                    Price = model.Price,
                    GoodCount = model.GoodCount,
                    Photo = model.Photo
                };

                using (var db = new GoodContext())
                {
                    db.Goods.Add(good);
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                    catch { }
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult GoodDelete(int id)
        {
            ViewBag.Name = db.Goods.First(x => x.GoodId == id).GoodName;
            return PartialView();
        }

        [HttpPost]
        [ActionName("GoodDelete")]
        [Authorize]
        public async Task<ActionResult> GoodDeleteConfirmed(int id)
        {
            try
            {
                Good tmp = await db.Goods.FindAsync(id);
                if (tmp != null)
                {
                    db.Goods.Remove(tmp);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch { }
            
            return RedirectToAction("Index", "Admin");
        }

        [Authorize]
        public async Task<ActionResult> GoodEdit(int id)
        {
            Good good = await db.Goods.FindAsync(id);
            if (good != null)
            {
                EditGoodModel model = new EditGoodModel
                {
                    GoodId = good.GoodId,
                    GoodName = good.GoodName,
                    Manufacturer = good.Manufacturer,
                    Category = good.Category,
                    Price = good.Price,
                    GoodCount = good.GoodCount,
                    Photo = good.Photo
                };
                return PartialView(model);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> GoodEdit(EditGoodModel model)
        {
            Good good = await db.Goods.FindAsync(model.GoodId);
            if (good != null)
            {
                good.GoodName = model.GoodName;
                good.Manufacturer = model.Manufacturer;
                good.Category = model.Category;
                good.Price = model.Price;//Convert.ToDecimal(model.Price, CultureInfo.InvariantCulture);
                good.GoodCount = model.GoodCount;
                good.Photo = model.Photo;

                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return PartialView(model);
        }

        [Authorize]
        public ActionResult Administrators()
        {
            List<ApplicationUser> users = UsDB.Users.ToList();
            return View(users);
        }

    }
}