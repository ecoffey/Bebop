using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Builder;
using System.Reflection;
using System.Web.Routing;
using Autofac;

namespace Bebop
{
	public abstract class BebopApplication : IBebopApplication
	{
		#region IApplication Members

		public abstract IEnumerable<Route> Map(RouteCollection routes);

		#endregion

		#region IModule Members

		public void Configure(IContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			var builder = new ContainerBuilder();

			var viewTypes =
				from type in Assembly.GetAssembly(this.GetType()).GetTypes()
				where typeof(IView).IsAssignableFrom(type)
				select type;

			foreach (var viewType in viewTypes)
			{
				builder.Register(viewType).FactoryScoped();
			}

			this.Load(builder);

			builder.Build(container);
		}

		#endregion

		protected virtual void Load(ContainerBuilder builder)
		{
		}
	}
}
