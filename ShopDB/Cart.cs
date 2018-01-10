using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CardId { get; set; }

        public int GoodId { get; set; }

        public int Count { get; set; }

        public DateTime DateCreate { get; set; }

        public virtual Good Good { get; set; }
    }
}
