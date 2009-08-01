using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop
{
    internal static class RouteMapping
    {
		internal static void MapSubRoutes(
			this RouteCollection routes,
			string root,
			IEnumerable<BebopRoute> subRoutes)
		{
			if (routes == null)
			{
				throw new ArgumentNullException("routes");
			}

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

				routes.Add(route);
			}
		}
    }
}
