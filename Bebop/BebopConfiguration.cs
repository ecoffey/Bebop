using System;
using System.Collections.Generic;
using System.Web.Routing;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Web;

namespace Bebop
{
    public class BebopConfiguration
    {
        private readonly IContainer _container;
        private readonly ContainerBuilder _containerBuilder;
        private readonly BebopRouteFactory _routeFactory;
        private readonly RouteCollection _routes;

    	private readonly Dictionary<string, BebopApplication> _applications;

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

            _container = new Container();
            _routeFactory = new BebopRouteFactory(_container);

        	_applications = new Dictionary<string, BebopApplication>();
        }

		public BebopConfiguration AddApplication(BebopApplication application)
		{
			return AddApplication(String.Empty, application);
		}

        public BebopConfiguration AddApplication(string urlRoot, BebopApplication application)
        {
            if (urlRoot == null)
            {
				throw new ArgumentNullException("urlRoot");
            }

            if (application == null)
            {
                throw new ArgumentNullException("application");
            }

			if (_applications.ContainsKey(urlRoot))
			{
				throw new InvalidOperationException(
					String.Format(
						"URL root '{0}' already contains application '{1}'",
						urlRoot,
						_applications[urlRoot].GetType().FullName));
			}

            _containerBuilder.RegisterModule(application);

            _routes.MapSubRoutes(urlRoot, application.Map(_routeFactory));

        	_applications[urlRoot] = application;

            return this;
        }

        public void Build()
        {
        	_containerBuilder.Update(_container);
        }
    }
}