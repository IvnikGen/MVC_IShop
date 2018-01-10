namespace MVC_IShop.NewDBISHop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ISHOpDB : DbContext
    {
        public ISHOpDB()
            : base("name=ISHOpDB")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
