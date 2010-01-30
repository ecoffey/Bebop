using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Bebop
{
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

		public BebopRoute<TResource> Create<TResource>(string url) where TResource : IResource
		{
			return new BebopRoute<TResource>(url, _container);
		}
	}
}
