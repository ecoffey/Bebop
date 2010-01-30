using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;

namespace Bebop
{
	public sealed class TemplatePageResponse : IResourceResponse
	{
		private string _virtualPath;
		private IDictionary<string, object> _templateContext;

		public TemplatePageResponse(string virtualPath)
		{
			if (String.IsNullOrEmpty(virtualPath))
			{
				throw new ArgumentOutOfRangeException("virtualPath");
			}

			_virtualPath = virtualPath;
		}

		public TemplatePageResponse(string virtualPath, IDictionary<string, object> templateContext)
		{
			if (String.IsNullOrEmpty(virtualPath))
			{
				throw new ArgumentOutOfRangeException("virtualPath");
			}

			if (templateContext == null)
			{
				throw new ArgumentNullException("templateContext");
			}

			_virtualPath = virtualPath;
			_templateContext = templateContext;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			var page = BuildManager.CreateInstanceFromVirtualPath(_virtualPath, typeof(TemplatePage)) as TemplatePage;

			page.TemplateContext = _templateContext;

			page.ProcessRequest(HttpContext.Current);
		}

		#endregion
	}
}
