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

            var route = new Route(url, new RouteHandler<T>());

            routes.Add(route);

            return route;
        }

		public static void Map(
			this RouteCollection routes,
			string root,
			IUrlConfiguration urlConfiguration)
		{
			if (routes == null)
			{
				throw new ArgumentNullException("routes");
			}

			if (String.IsNullOrEmpty(root))
			{
				throw new ArgumentOutOfRangeException("root");
			}
			
			if (urlConfiguration == null)
			{
				throw new ArgumentNullException("urlConfiguration");
			}

			foreach (var route in urlConfiguration.Map(routes))
			{
				route.Url = String.Format("{0}{1}", root, route.Url);
			}
		}
    }
}
