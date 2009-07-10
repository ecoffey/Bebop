using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Bebop.Example.App
{
	public class UrlConfiguration : IUrlConfiguration
	{
		#region IUrlConfiguration Members

		public IEnumerable<Route> Map(RouteCollection routes)
		{
			yield return routes.Map<BlahView>("blah");
		}

		#endregion
	}
}
