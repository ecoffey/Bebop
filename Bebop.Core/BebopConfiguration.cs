﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Builder;
using System.Web.Routing;
using Autofac.Integration.Web;

namespace Bebop
{
	public class BebopConfiguration
	{
		private RouteCollection _routes;
		private ContainerBuilder _containerBuilder;

		public BebopConfiguration(RouteCollection routes, ContainerBuilder containerBuilder)
		{
			if (routes == null)
			{
				throw new ArgumentNullException("routes");
			}

			if (containerBuilder == null)
			{
				throw new ArgumentNullException("containerBuilder");
			}

			_routes = routes;
			_containerBuilder = containerBuilder;
		}

		public BebopConfiguration AddApplication(string urlRoot, IBebopApplication application)
		{
			if (String.IsNullOrEmpty(urlRoot))
			{
				throw new ArgumentOutOfRangeException("urlRoot");
			}

			if (application == null)
			{
				throw new ArgumentNullException("application");
			}

			_containerBuilder.RegisterModule(application);
			_routes.MapSubRoutes(urlRoot, application.Map());

			return this;
		}

		public IContainerProvider Build()
		{
			var containerProvider = new ContainerProvider(_containerBuilder.Build());

			RouteHandler.Container = containerProvider.RequestContainer;

			return containerProvider;
		}
	}
}
