using System;
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
            _routes.MapSubRoutes(urlRoot, application.Map(_routeFactory));

            return this;
        }

        public IContainerProvider Build()
        {
        	_containerBuilder.Update(_container);

            return new ContainerProvider(_container);
        }
    }
}