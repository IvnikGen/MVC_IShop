﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_IShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }

       // public string UserRole { get; set; }

        public ApplicationUser()
        {
        }
    }
}
