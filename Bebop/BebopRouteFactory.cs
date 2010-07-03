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

		public IMapResourceTo<TResource> Map<TResource>() where TResource : IResource
		{
			return new MapResourceTo<TResource>(_container);
		}

		private sealed class MapResourceTo<TResource> : IMapResourceTo<TResource> where TResource : IResource
		{
			private readonly IContainer _container;

			public MapResourceTo(IContainer container)
			{
				_container = container;
			}

			public BebopRoute<TResource> To(string url)
			{
				return new BebopRoute<TResource>(url, _container);
			}
		}
	}
}
