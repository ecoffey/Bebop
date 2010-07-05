using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Autofac;

namespace Bebop
{
	public class BebopRoute : Route
	{
		public BebopRoute(string url, Type resourceType, IContainer container)
			: base(url, new RouteHandler(resourceType, container))
		{
		}

	}

	public sealed class BebopRoute<TResource> : BebopRoute where TResource : IResource
	{
		internal BebopRoute(string url, IContainer container)
			: base(url, typeof(TResource), container)
		{
		}

	}
}
