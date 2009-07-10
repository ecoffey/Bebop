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
            var route = new Route(url, new RouteHandler<T>());

            routes.Add(route);

            return route;
        }

		public static void Map(
			this RouteCollection routes,
			string root,
			IUrlConfiguration urlConfiguration)
		{
			foreach (var route in urlConfiguration.Map(routes))
			{
				route.Url = String.Format("{0}{1}", root, route.Url);
			}
		}
    }
}
