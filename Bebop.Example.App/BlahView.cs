using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bebop.Template;

namespace Bebop.Example.App
{
	public sealed class BlahView : View
	{
		private SomeService _someService;

		public BlahView(SomeService someService)
		{
			if (someService == null)
			{
				throw new ArgumentNullException("someService");
			}

			_someService = someService;
		}

		public override IViewResponse Get(ViewRequestContext context)
		{
			var templateContext = new TemplateContext()
			{
				{ "a", 1 },
				{ "b", 2}
			};

			var template = new BebopTemplate(GenerateNodes());

			return new TemplateResponse(template, templateContext);
		}

		private IEnumerable<INode> GenerateNodes()
		{
			yield return new ContentNode(@"<html><head><title>blah</title></head><body><p>");
			yield return new VariableNode("a");
			yield return new ContentNode(@"</p><ul>");
			yield return InnerTemplate();
			yield return new ContentNode(@"</ul><p>");
			yield return new VariableNode("b");
			yield return new ContentNode(@"</p></body></html>");
		}

		private LoopNode InnerTemplate()
		{
			var innerTemplate = new BebopTemplate(GenerateInnerNodes());

			return new LoopNode("i", new string[] { "a", "b", "c" }.AsEnumerable(), innerTemplate);
		}

		private IEnumerable<INode> GenerateInnerNodes()
		{
			yield return new ContentNode("<li>");
			yield return new VariableNode("i");
			yield return new ContentNode("</li>");
		}
	}
}
