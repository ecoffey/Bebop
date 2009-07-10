using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public interface IView
	{
		IViewResponse Get(HttpContext context);

		IViewResponse Post(HttpContext context);

		IViewResponse Put(HttpContext context);

		IViewResponse Delete(HttpContext context);
	}
}
