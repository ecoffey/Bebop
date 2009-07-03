using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Bebop;

namespace RoutingTest
{
    public class SomethingView : View
    {
		protected override IViewResponse Get(HttpContext context)
		{
			return new SimpleResponse("Hello World");
		}
    }
}
