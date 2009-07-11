using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bebop.Example.App
{
	public sealed class BlahView : View
	{
		public override IViewResponse Get(ViewRequestContext context)
		{
			return new TemplatePageResponse(
				"~/Blah.aspx",
				new Dictionary<string, object>
				{
					{ "Something", "Hello World" }
				});
		}
	}
}
