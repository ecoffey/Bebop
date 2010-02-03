using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bebop
{
    public abstract class Resource : IResource
    {
		public virtual IResourceResponse Get(ResourceRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'GET'");
		}

		public virtual IResourceResponse Post(ResourceRequestContext context)
        {
            throw new InvalidOperationException("This view does not support the verb 'POST'");
        }

		public virtual IResourceResponse Put(ResourceRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'PUT'");
		}

		public virtual IResourceResponse Delete(ResourceRequestContext context)
		{
			throw new InvalidOperationException("This view does not support the verb 'DELETE'");
		}
    }
}
