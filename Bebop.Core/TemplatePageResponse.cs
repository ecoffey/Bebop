using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;

namespace Bebop
{
	public sealed class TemplatePageResponse : IViewResponse
	{
		private string _virtualPath;

		public TemplatePageResponse(string virtualPath)
		{
			_virtualPath = virtualPath;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			var page = BuildManager.CreateInstanceFromVirtualPath(_virtualPath, typeof(TemplatePage)) as TemplatePage;

			page.ProcessRequest(HttpContext.Current);
		}

		#endregion
	}
}
