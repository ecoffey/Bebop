using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using System.Web.Routing;
using System.Reflection;
using Autofac.Core;

namespace Bebop
{
	public interface IBebopApplication : IModule
	{
		IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory);
	}
}
