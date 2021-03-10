using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Models;

namespace OnlineShop.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the OnlineShopUser class
    public class OnlineShopUser : IdentityUser
    {

        public List<ProductModel> Cart;

        public OnlineShopUser()
        {
            Cart = new List<ProductModel>();
        }
    }
}
