using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using System.Web.Routing;
using System.Reflection;

namespace Bebop
{
	public interface IBebopApplication : IModule
	{
		IEnumerable<Route> Map(RouteCollection routes);
	}
}
