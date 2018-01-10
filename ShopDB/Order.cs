using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int GoodId { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Good Good { get; set; }

        public virtual Order Order { get; set; }
    }
}
