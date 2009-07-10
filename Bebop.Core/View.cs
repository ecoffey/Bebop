using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bebop
{
    public abstract class View : IView
    {
		public virtual IViewResponse Get(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'GET'");
		}

        public virtual IViewResponse Post(HttpContext context)
        {
            throw new InvalidOperationException("This view does not support the verb 'POST'");
        }

		public virtual IViewResponse Put(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'PUT'");
		}

		public virtual IViewResponse Delete(HttpContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'DELETE'");
		}
    }
}
