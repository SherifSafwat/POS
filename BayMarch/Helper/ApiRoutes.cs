using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Helper
{
    public static class ApiRoutes
    {
        public const String Root = "api";
        public const String Version = "";
        public const String Base = Root + "/" + Version;

        public static class PropductRoutes
        {
            public const String GetAll = Base + "products/GetAll";
            public const String GetById = Base + "products";
            public const String Create = Base + "products";
            public const String Update = Base + "products";
            public const String Delete = Base + "products";
        }
    }
}
