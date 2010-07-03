using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace Bebop
{
	public abstract class BebopApplication : IBebopApplication
	{
		public abstract IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory);

		protected virtual void Load(ContainerBuilder builder)
		{
		}

		public void Configure(IComponentRegistry container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			var builder = new ContainerBuilder();
			
			var resourceTypes =
				from type in this.GetType().Assembly.GetTypes()
				where typeof(IResource).IsAssignableFrom(type)
				select type;

			foreach (var resourceType in resourceTypes)
			{
				builder.RegisterType(resourceType).InstancePerDependency();
			}

			Load(builder);

			builder.Update(container);
		}
	}
}
