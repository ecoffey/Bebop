using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bebop.Example.App
{
	public sealed class BlahView : View
	{
		public override IViewResponse Get(System.Web.HttpContext context)
		{
			return new TemplatePageResponse("~/Blah.aspx");
		}
	}
}
