namespace MVC_IShop.NewDBISHop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int GoodId { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Good Good { get; set; }

        public virtual Order Order { get; set; }
    }
}
