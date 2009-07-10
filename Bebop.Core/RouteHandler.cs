using System;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
    public sealed class RouteHandler<T> : IRouteHandler where T : IView, new()
    {
        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			return new HttpHandler(
				requestContext,
				new T());
        }

        #endregion
    }
}
