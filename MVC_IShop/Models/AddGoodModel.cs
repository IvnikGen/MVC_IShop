using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_IShop.Models
{
    public class AddGoodModel
    {
        public int GoodId { get; set; }

        [Required]
        public string GoodName { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int GoodCount { get; set; }

        [Required]
        public string Photo { get; set; }
    }
}