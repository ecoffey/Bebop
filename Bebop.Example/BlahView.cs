using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bebop.Example
{
	public sealed class BlahView : View
	{
		protected override IViewResponse Get(HttpContext context)
		{
			return new TemplatePageResponse("~/Blah.aspx");
		}
	}
}
