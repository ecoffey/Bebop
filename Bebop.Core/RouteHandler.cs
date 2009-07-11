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
		internal static IContainer Container { get; set; }

		private Type _viewType;

		public RouteHandler(Type viewType)
		{
			if (viewType == null)
			{
				throw new ArgumentNullException("viewType");
			}

			_viewType = viewType;
		}

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			return new HttpHandler(
				requestContext,
				Container.Resolve(_viewType) as IView);
        }

        #endregion
    }
}
