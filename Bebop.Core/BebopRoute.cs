using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Autofac;

namespace Bebop
{
	public abstract class BebopRoute : Route
	{
		protected BebopRoute(string url, Type viewType, IContainer container)
			: base(url, new RouteHandler(viewType, container))
		{
		}

	}

	public sealed class BebopRoute<TView> : BebopRoute where TView : IView
	{
		internal BebopRoute(string url, IContainer container)
			: base(url, typeof(TView), container)
		{
		}

	}
}
