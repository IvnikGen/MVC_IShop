using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    public class GoodContext : DbContext
    {
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public GoodContext() : base("IShopGoods")
        { }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Good> Goods { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
