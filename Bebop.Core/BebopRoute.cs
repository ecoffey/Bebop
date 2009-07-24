using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop
{
	public abstract class BebopRoute : Route
	{
		public BebopRoute(string url, Type viewType)
			: base(url, new RouteHandler(viewType))
		{
		}

	}

	public sealed class BebopRoute<TView> : BebopRoute where TView : IView
	{
		public BebopRoute(string url)
			: base(url, typeof(TView))
		{
		}

	}
}
