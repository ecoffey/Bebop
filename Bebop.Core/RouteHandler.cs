using System;
using System.Web;
using System.Web.Routing;
using Autofac.Integration.Web;
using System.Reflection;
using System.Linq;
using Autofac;

namespace Bebop
{
    public sealed class RouteHandler : IRouteHandler
    {
		private Type _viewType;
		private IContainer _container;

		public RouteHandler(Type viewType, IContainer container)
		{
			if (viewType == null)
			{
				throw new ArgumentNullException("viewType");
			}

			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_viewType = viewType;
			_container = container;
		}

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			return new HttpHandler(
				requestContext,
				_container.Resolve(_viewType) as IView);
        }

        #endregion
    }
}
