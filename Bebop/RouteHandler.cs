using System;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using System.Linq;
using Autofac;

namespace Bebop
{
    public sealed class RouteHandler : IRouteHandler
    {
		private readonly Type _resourceType;
		private readonly IContainer _container;

		public RouteHandler(Type resourceType, IContainer container)
		{
			if (resourceType == null)
			{
				throw new ArgumentNullException("resourceType");
			}

			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_resourceType = resourceType;
			_container = container;
		}

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			using (var scope = _container.BeginLifetimeScope())
			{
				return new HttpHandler(
					requestContext,
					scope.Resolve(_resourceType) as IResource);
			}
        }

        #endregion
    }
}
