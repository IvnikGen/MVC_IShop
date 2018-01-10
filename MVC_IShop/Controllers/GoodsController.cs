using MVC_IShop.Models;
using MVC_IShop.NewDBISHop;
//using ShopDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_IShop.Controllers
{
    public class GoodsController : Controller
    {
        ISHOpDB db = new ISHOpDB();
        // GET: Goods
        public ActionResult Index(int id = 1)
        {
            List<Good> goods = db.Goods.ToList();

            ViewBag.Index = id;
            ViewBag.Count = goods.Count();
            var res = goods.Skip((id - 1) * 6).Take(6).ToList();

            return View();
        }

        public ActionResult GetGoodsList(int id = 1, string filter = "Все", string filterdata = "", string sort = "")
        {
            List<Good> goods = db.Goods.ToList();
            List<Good> res = new List<Good>();

            List<string> filters = new List<string>();
            foreach (string f in filterdata.Split(' '))
                filters.Add(f.Trim());

            switch (filter)
            {
                case "Все":
                    res = goods.Skip((id - 1) * 6).Take(6).ToList();
                    break;
                case "Category":
                    {
                        res = goods.Where(x => filters.Contains(x.Category) && filters.Contains(x.Manufacturer)).ToList();
                        if (res.Count == 0)
                            res = goods.Where(x => filters.Contains(x.Category)).ToList();
                        if (res.Count == 0)
                            res = goods.Where(x => filters.Contains(x.Manufacturer)).ToList();
                    }
                    break;
                case "Manufacturer":
                    {
                        res = goods.Where(x => filters.Contains(x.Category) && filters.Contains(x.Manufacturer)).ToList();
                        if (res.Count == 0)
                            res = goods.Where(x => filters.Contains(x.Manufacturer)).ToList();
                        if (res.Count == 0)
                            res = goods.Where(x => filters.Contains(x.Category)).ToList();
                    }
                    break;
            }

            if(!String.IsNullOrEmpty(sort) && sort == "От дешевыхк дорогим")
                return PartialView(res.OrderBy(x=> x.Price));
            if (!String.IsNullOrEmpty(sort) && sort == "От дорогих к дешевым")
                return PartialView(res.OrderByDescending(x => x.Price));

            return PartialView(res);
        }
    }
}