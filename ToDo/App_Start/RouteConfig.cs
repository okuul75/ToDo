using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { Controller = "ToDoTask", Action = "List", state = (string)null, page = 1}
                );
            
            routes.MapRoute(
                null,
                "Strona{page}",
                new { Controller = "ToDoTask", Action = "List", state = (string)null},
                new {page = @"\d+" }
                );

            routes.MapRoute(
                null,
                "{state}",
                new { Controller = "ToDoTask", Action = "List", state = (string)null, page = 1}
            );

            routes.MapRoute(
                null,
                "{state}/Strona{page}",
                new { Controller = "ToDoTask", Action = "List"},
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
