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

		public BebopRoute<TView> Create<TView>(string url) where TView : IView
		{
			return new BebopRoute<TView>(url, _container);
		}
	}
}
