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
			var d = context.Values["d"];

			return new SimpleResponse(String.Format("Hello {0}", d));
		}
	}
}
