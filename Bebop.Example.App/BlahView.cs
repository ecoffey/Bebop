using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			return new TemplatePageResponse(
				"~/Blah.aspx",
				new Dictionary<string, object>
				{
					{ "Something", "Hello World" },
					{ "AnotherThing", _someService.DoWork() }
				});
		}
	}
}
