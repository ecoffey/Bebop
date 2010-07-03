using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
	internal sealed class HttpHandler : IHttpHandler
	{
		private const string VERB_GET = "GET";
		private const string VERB_POST = "POST";
		private const string VERB_PUT = "PUT";
		private const string VERB_DELETE = "DELETE";

		private readonly RequestContext _requestContext;
		private readonly IResource _resource;

		internal HttpHandler(RequestContext requestContext, IResource resource)
		{
			if (requestContext == null)
			{
				throw new ArgumentNullException("requestContext");
			}

			if (resource == null)
			{
				throw new ArgumentNullException("resource");
			}

			_requestContext = requestContext;
			_resource = resource;
		}

		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			IResourceResponse resourceResponse;
			var resourceRequestContext = new ResourceRequestContext(context, _requestContext.RouteData.Values);
			var requestVerb = context.Request.HttpMethod;

			if (requestVerb == VERB_GET)
			{
				resourceResponse = _resource.Get(resourceRequestContext);
			}
			else if (requestVerb == VERB_POST)
			{
				resourceResponse = _resource.Post(resourceRequestContext);
			}
			else if (requestVerb == VERB_PUT)
			{
				resourceResponse = _resource.Put(resourceRequestContext);
			}
			else if (requestVerb == VERB_DELETE)
			{
				resourceResponse = _resource.Delete(resourceRequestContext);
			}
			else
			{
				throw new InvalidOperationException(
					String.Format("Unknown verb {0}", requestVerb));
			}

			if (resourceResponse == null)
			{
				throw new InvalidOperationException(
					String.Format(
						"Resource type '{0}' returned a null response for the verb '{1}'",
						_resource.GetType().FullName,
						requestVerb));
			}

			resourceResponse.Execute(context.Response);
		}

		#endregion
	}
}
