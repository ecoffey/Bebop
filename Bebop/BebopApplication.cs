using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Builder;
using System.Reflection;
using System.Web.Routing;
using Autofac;
using Autofac.Core;

namespace Bebop
{
	public abstract class BebopApplication : IBebopApplication
	{
		#region IApplication Members

		public abstract IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory);

		#endregion

		#region IModule Members

		public void Configure(IContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			var builder = new ContainerBuilder();

			var resourceTypes =
				from type in Assembly.GetAssembly(this.GetType()).GetTypes()
				where typeof(IResource).IsAssignableFrom(type)
				select type;

			foreach (var resourceType in resourceTypes)
			{
				builder.RegisterType(resourceType).InstancePerDependency();
			}

			this.Load(builder);

			builder.Update(container);
		}

		#endregion

		protected virtual void Load(ContainerBuilder builder)
		{
		}

		public void Configure(IComponentRegistry componentRegistry)
		{
			throw new NotImplementedException();
		}
	}
}
