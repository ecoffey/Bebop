using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public interface IViewResponse
	{
		void Execute(HttpResponse response);
	}
}
