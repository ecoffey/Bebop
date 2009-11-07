using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bebop.Template;
using System.Web;
using System.IO;

namespace Bebop
{
	public static class TemplateRendering
	{
		internal static ITemplateEngine TemplateEngine { get; set; }

		public static IViewResponse Render(
			this IView view,
			string templateFilePath,
			TemplateContext templateContext)
		{
			return new TemplateResponse(
				TemplateEngine.CreateFromStream(new FileStream(templateFilePath, FileMode.Open)),
				templateContext);
		}
	}

	public sealed class TemplateResponse : IViewResponse
	{
		private ITemplate _template;
		private TemplateContext _templateContext;

		public TemplateResponse(
			ITemplate template,
			TemplateContext templateContext)
		{
			_template = template;
			_templateContext = templateContext;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			response.Output.Write(_template.Apply(_templateContext));
		}

		#endregion
	}
}
