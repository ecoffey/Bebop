using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Bebop
{
	public sealed class BebopRouteFactory
	{
		private readonly IContainer _container;

		internal BebopRouteFactory(IContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_container = container;
		}

		internal BebopRoute Map(Type resourceType, string url)
		{
			return new BebopRoute(url, resourceType, _container);
		}
	}
}
