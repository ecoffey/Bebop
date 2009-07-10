using System;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
    public sealed class BebopRouteHandler<T> : IRouteHandler where T : IView, new()
    {
        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			var view = new T();

            return view as IHttpHandler;
        }

        #endregion
    }
}
