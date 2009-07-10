using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop
{
	public interface IUrlConfiguration
	{
		IEnumerable<Route> Map(RouteCollection routes);
	}
}
