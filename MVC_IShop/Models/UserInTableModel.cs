using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_IShop.Models
{
    public class UserInTableModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int Year { get; set; }

        public string UserRole { get; set; }
    }
}