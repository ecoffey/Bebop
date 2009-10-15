using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bebop.Template;

namespace Bebop
{
    public abstract class View : IView
    {
		public virtual IViewResponse Get(ViewRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'GET'");
		}

		public virtual IViewResponse Post(ViewRequestContext context)
        {
            throw new InvalidOperationException("This view does not support the verb 'POST'");
        }

		public virtual IViewResponse Put(ViewRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'PUT'");
		}

		public virtual IViewResponse Delete(ViewRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'DELETE'");
		}
    }
}
