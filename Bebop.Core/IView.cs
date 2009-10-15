using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Bebop.Template;

namespace Bebop
{
	public interface IView
	{
		IViewResponse Get(ViewRequestContext context);

		IViewResponse Post(ViewRequestContext context);

		IViewResponse Put(ViewRequestContext context);

		IViewResponse Delete(ViewRequestContext context);
	}
}
