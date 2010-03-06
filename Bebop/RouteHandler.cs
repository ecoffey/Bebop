﻿using System;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using System.Linq;
using Autofac;

namespace Bebop
{
    public sealed class RouteHandler : IRouteHandler
    {
		private Type _resourceType;
		private IContainer _container;

		public RouteHandler(Type resourceType, IContainer container)
		{
			if (resourceType == null)
			{
				throw new ArgumentNullException("viewType");
			}

			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_resourceType = resourceType;
			_container = container;
		}

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
			return new HttpHandler(
				requestContext,
				_container.Resolve(_resourceType) as IResource);
        }

        #endregion
    }
}
