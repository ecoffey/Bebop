using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bebop.Example.App
{
	public sealed class BlahResource : Resource
	{
		private SomeService _someService;

		public BlahResource(SomeService someService)
		{
			if (someService == null)
			{
				throw new ArgumentNullException("someService");
			}

			_someService = someService;
		}

		public override IResourceResponse Get(ResourceRequestContext context)
		{
			var link = Uri.UnescapeDataString(context.Values["d"].ToString());
			return new SimpleResponse(link);
		}
	}
}
