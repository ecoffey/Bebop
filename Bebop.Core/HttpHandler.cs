using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
	public sealed class HttpHandler : IHttpHandler
	{
		private const string VERB_GET = "GET";
		private const string VERB_POST = "POST";
		private const string VERB_PUT = "PUT";
		private const string VERB_DELETE = "DELETE";

		private RequestContext _requestContext;
		private IView _view;

		public HttpHandler(RequestContext requestContext, IView view)
		{
			if (requestContext == null)
			{
				throw new ArgumentNullException("requestContext");
			}

			if (view == null)
			{
				throw new ArgumentNullException("view");
			}

			_requestContext = requestContext;
			_view = view;
		}

		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			var viewResponse = null as IViewResponse;
			var viewRequestContext = new ViewRequestContext(context, _requestContext.RouteData.Values);
			var requestVerb = context.Request.HttpMethod;

			if (requestVerb == VERB_GET)
			{
				viewResponse = _view.Get(viewRequestContext);
			}
			else if (requestVerb == VERB_POST)
			{
				viewResponse = _view.Post(viewRequestContext);
			}
			else if (requestVerb == VERB_PUT)
			{
				viewResponse = _view.Put(viewRequestContext);
			}
			else if (requestVerb == VERB_DELETE)
			{
				viewResponse = _view.Delete(viewRequestContext);
			}
			else
			{
				throw new InvalidOperationException(
					String.Format("Unknown verb {0}", requestVerb));
			}

			if (viewResponse != null)
			{
				viewResponse.Execute(context.Response);
			}
		}

		#endregion
	}
}
