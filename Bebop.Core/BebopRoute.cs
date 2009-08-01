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
		public BebopRoute(string url, Type viewType, IContainer container)
			: base(url, new RouteHandler(viewType, container))
		{
		}

	}

	public sealed class BebopRoute<TView> : BebopRoute where TView : IView
	{
		public BebopRoute(string url, IContainer container)
			: base(url, typeof(TView), container)
		{
		}

	}

	public sealed class BebopRouteFactory
	{
		private IContainer _container;

		internal BebopRouteFactory(IContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_container = container;
		}

		public BebopRoute<TView> Create<TView>(string url) where TView : IView
		{
			return new BebopRoute<TView>(url, _container);
		}
	}
}
