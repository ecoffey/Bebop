using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Bebop.Template
{
	public sealed class BebopTemplateResponse : IViewResponse
	{
		private static ITemplateEngine _templateEngine = new BebopTemplateEngine();

		private string _fileName;
		private TemplateContext _templateContext;

		public BebopTemplateResponse(
			string fileName,
			TemplateContext templateContext)
		{
			_fileName = fileName;
			_templateContext = templateContext;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			var fileStream = new FileStream(_fileName, FileMode.Open);

			var template = _templateEngine.CreateFromStream(fileStream);

			response.Output.Write(template.Apply(_templateContext));
		}

		#endregion
	}

	public sealed class TemplateContext : Dictionary<string, object>
	{
		public TemplateContext()
			: base()
		{
		}

		public TemplateContext(TemplateContext context)
			: base(context)
		{
		}
	}

	public interface ITemplate
	{
		string Apply(TemplateContext context);
	}

	public sealed class BebopTemplate : ITemplate
	{
		#region ITemplate Members

		public string Apply(TemplateContext context)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

	public interface ITemplateEngine
	{
		ITemplate CreateFromStream(Stream stream);
	}

	public sealed class BebopTemplateEngine : ITemplateEngine
	{
		#region ITemplateEngine Members

		public ITemplate CreateFromStream(Stream stream)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

}
