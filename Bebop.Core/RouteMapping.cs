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
			where T : IView, new()
        {
			if (routes == null)
			{
				throw new ArgumentNullException("routes");
			}

			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentOutOfRangeException("url");
			}

            var route = new Route(url, new RouteHandler(typeof(T)));

            routes.Add(route);

            return route;
        }

		internal static void MapSubRoutes(
			string root,
			IEnumerable<Route> subRoutes)
		{
			if (String.IsNullOrEmpty(root))
			{
				throw new ArgumentOutOfRangeException("root");
			}
			
			if (subRoutes == null)
			{
				throw new ArgumentNullException("subRoutes");
			}

			foreach (var route in subRoutes)
			{
				route.Url = String.Format("{0}{1}", root, route.Url);
			}
		}
    }
}
