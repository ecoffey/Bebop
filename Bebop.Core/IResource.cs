using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public interface IResource
	{
		IResourceResponse Get(ResourceRequestContext context);

		IResourceResponse Post(ResourceRequestContext context);

		IResourceResponse Put(ResourceRequestContext context);

		IResourceResponse Delete(ResourceRequestContext context);
	}
}
