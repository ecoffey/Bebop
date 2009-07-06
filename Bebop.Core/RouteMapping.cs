using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop
{
    public static class RouteMapping
    {
        public static Route Map<T>(
            this RouteCollection routes,
            string url)
			where T : new()
        {
            var route = new Route(url, new BebopRouteHandler<T>());

            routes.Add(route);

            return route;
        }
    }
}
