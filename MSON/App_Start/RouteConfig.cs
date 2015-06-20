using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSON
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");




            routes.MapRoute(
                name: "RouteSanPham",
                url: "NguoiDung/SanPham/{page}/{loai}",
                defaults: new { controller = "NguoiDung", action = "SanPham", page = 1, loai = 0 }
                //new { controller = "NguoiDung", action = "SanPham", page = UrlParameter.Optional}
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NguoiDung", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
