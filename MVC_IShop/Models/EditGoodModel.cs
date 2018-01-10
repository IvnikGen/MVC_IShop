using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_IShop.Models
{
    public class EditGoodModel
    {
        public int GoodId { get; set; }

        public string GoodName { get; set; }

        public string Manufacturer { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int GoodCount { get; set; }

        public string Photo { get; set; }
    }
}