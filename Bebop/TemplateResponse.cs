using System.Reflection;
using System.Web;
using NHaml;

namespace Bebop
{
	public sealed class TemplateResponse : IResourceResponse
	{
		private readonly string _viewPath;
		private readonly TemplateEngine _templateEngine;

		public TemplateResponse(string viewPath)
		{
			_viewPath = viewPath;
			_templateEngine = new TemplateEngine();

			// TODO: Probably going to need this at some point; figure out why :-P
			//_templateEngine.Options.AddUsing("System.Web");
			//_templateEngine.Options.AddUsing("System.Web.Routing");
			//_templateEngine.Options.AddUsing("NHaml");

			//foreach (var referencedAssembly in typeof(Resource).Assembly.GetReferencedAssemblies())
			//{
			//    _templateEngine.Options.AddReference(Assembly.Load(referencedAssembly).Location);
			//} 
		}

		public void Execute(HttpResponse response)
		{
			var path = HttpContext.Current.Request.MapPath(_viewPath);

			var compiledTemplate = _templateEngine.Compile(new[] { path }, typeof(Template));

			var template = compiledTemplate.CreateInstance();

			template.Render(response.Output);
		}
	}
}