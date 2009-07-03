﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop
{
    public static class RouteMapping
    {
        private static IRouteHandler _routeHandler = new BebopRouteHandler();

        public static Route Map(
            this RouteCollection routes,
            string url,
            Type viewType)
        {
            var route = new Route(url, _routeHandler);

            route.DataTokens = new RouteValueDictionary() { { "ViewType", viewType } };

            routes.Add(route);

            return route;
        }
    }
}