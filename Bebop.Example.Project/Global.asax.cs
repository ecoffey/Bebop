using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Autofac.Integration.Web;
using Autofac.Builder;
using Bebop;

namespace Bebop.Example.Project
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
		public IContainerProvider ContainerProvider { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
			var config = new BebopConfiguration(RouteTable.Routes, new ContainerBuilder());

			config.AddApplication("something/", new Bebop.Example.App.Application());

			ContainerProvider = config.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}