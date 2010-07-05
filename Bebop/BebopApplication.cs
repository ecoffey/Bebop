using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Module = Autofac.Module;

namespace Bebop
{
	public abstract class BebopApplication : IModule
	{
		private readonly ContainerBuilder _registrations = new ContainerBuilder();
		private readonly IList<KeyValuePair<Type, string>> _routes = new List<KeyValuePair<Type, string>>();

		protected void Register(Action<ContainerBuilder> container)
		{
			container(_registrations);
		}

		protected void Map<TResource>(string url) where TResource : IResource
		{
			_routes.Add(new KeyValuePair<Type, string>(typeof(TResource), url));
		}

		internal IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory)
		{
			return _routes.Select(route => routeFactory.Map(route.Key, route.Value));
		}

		public void Configure(IComponentRegistry componentRegistry)
		{
			if (componentRegistry == null) throw new ArgumentNullException("componentRegistry");

			var builder = new ContainerBuilder();

			var resourceTypes =
				from type in this.GetType().Assembly.GetTypes()
				where typeof(IResource).IsAssignableFrom(type)
				select type;

			foreach (var resourceType in resourceTypes)
			{
				builder.RegisterType(resourceType).InstancePerDependency();
			}

			builder.Update(componentRegistry);
			_registrations.Update(componentRegistry);
		}
	}
}
