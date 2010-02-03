using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace Bebop
{
	public sealed class ResourceRequestContext
	{
		public HttpContext HttpContext { get; private set; }

		public RouteValueDictionary Values { get; private set; }

		public ResourceRequestContext(HttpContext httpContext, RouteValueDictionary values)
		{
			if (httpContext == null)
			{
				throw new ArgumentNullException("httpContext");
			}

			if (values == null)
			{
				throw new ArgumentNullException("values");
			}

			this.HttpContext = httpContext;
			this.Values = values;
		}
	}
}
