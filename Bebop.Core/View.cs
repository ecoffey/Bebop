using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bebop
{
    public abstract class View : IHttpHandler
    {
		private const string VERB_GET = "GET";
		private const string VERB_POST = "POST";
		private const string VERB_PUT = "PUT";
		private const string VERB_DELETE = "DELETE";

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
				viewResponse = this.Get(context);
			}
			else if (requestVerb == VERB_POST)
			{
				viewResponse = this.Post(context);
			}
			else if (requestVerb == VERB_PUT)
			{
				viewResponse = this.Put(context);
			}
			else if (requestVerb == VERB_DELETE)
			{
				viewResponse = this.Delete(context);
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

		protected virtual IViewResponse Get(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'GET'");
		}

        protected virtual IViewResponse Post(HttpContext context)
        {
            throw new InvalidOperationException("This view does not support the verb 'POST'");
        }

		protected virtual IViewResponse Put(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'PUT'");
		}

		protected virtual IViewResponse Delete(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'DELETE'");
		}
    }
}
