using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public sealed class RedirectResponse : IResourceResponse
	{
		private string _url;

		public RedirectResponse(string url)
		{
			_url = url;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			response.Redirect(_url);
		}

		#endregion
	}
}
