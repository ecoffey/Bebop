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
			string templateFilePath)
		{
			return new TemplateResponse(TemplateEngine.CreateFromStream(new FileStream(templateFilePath, FileMode.Open)));
		}
	}

	public class TemplateResponse : IViewResponse
	{
		private ITemplate _template;

		public TemplateResponse(ITemplate template)
		{
			if (template == null)
			{
				throw new ArgumentNullException("template");
			}

			_template = template;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
		}

		#endregion
	}
}
