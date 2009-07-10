using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public sealed class HttpHandler : IHttpHandler
	{
		private const string VERB_GET = "GET";
		private const string VERB_POST = "POST";
		private const string VERB_PUT = "PUT";
		private const string VERB_DELETE = "DELETE";

		private IView _view;

		public HttpHandler(IView view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}

			_view = view;
		}

		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			IViewResponse viewResponse = null;
			var requestVerb = context.Request.HttpMethod;

			if (requestVerb == VERB_GET)
			{
				viewResponse = _view.Get(context);
			}
			else if (requestVerb == VERB_POST)
			{
				viewResponse = _view.Post(context);
			}
			else if (requestVerb == VERB_PUT)
			{
				viewResponse = _view.Put(context);
			}
			else if (requestVerb == VERB_DELETE)
			{
				viewResponse = _view.Delete(context);
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
