using MVC_IShop.NewDBISHop;
//using ShopDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_IShop.Controllers
{
    public class NavigationController : Controller
    {
        static List<Good> goods = new ISHOpDB().Goods.ToList();
        // GET: Navigation
        public ActionResult Menu()
        {
            IEnumerable<string> groups = goods
                                .Select(x => x.Category)
                                .Distinct()
                                .ToList();
            return PartialView(groups);
        }

        public ActionResult Manufacturer()
        {
            IEnumerable<string> groups = goods
                                .Select(x => x.Manufacturer)
                                .Distinct()
                                .ToList();
            return PartialView(groups);
        }

        public ActionResult Search()
        {
            return PartialView();
        }
    }
}