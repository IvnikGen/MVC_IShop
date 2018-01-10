namespace MVC_IShop.NewDBISHop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart
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
