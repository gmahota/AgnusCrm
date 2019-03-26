using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.MVC
{
    public static partial class Pages
    {

        public static class HomeIndex
        {
            public const string Controller = "Home";
            public const string Action = "Index";
            public const string Role = "Home";
            public const string Url = "/Home/Index";
            public const string Name = "Home";
        }

        public static class ApplicationUser
        {
            public const string Controller = "ApplicationUser";
            public const string Action = "Index";
            public const string Role = "ApplicationUser";
            public const string Url = "/ApplicationUser/Index";
            public const string Name = "User Role";
        }

        public static class CustomersIndex
        {
            public const string Controller = "Customers";
            public const string Action = "Index";
            public const string Role = "Customer";
            public const string Url = "/Customers/Index";
            public const string Name = "Customer Role";
        }

        public static class PriceListIndex
        {
            public const string Controller = "PriceList";
            public const string Action = "Index";
            public const string Role = "PriceList";
            public const string Url = "/PriceList/Index";
            public const string Name = "Price List Role";
        }
    }
}
