using System;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
    public sealed class BebopRouteHandler : IRouteHandler
    {
        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var viewType = requestContext.RouteData.DataTokens["ViewType"] as Type;

            var constructor = viewType.GetConstructor(new Type[] { });

            var view = constructor.Invoke(null);

            return view as IHttpHandler;
        }

        #endregion
    }
}
