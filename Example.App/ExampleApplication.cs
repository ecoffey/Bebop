using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bebop;
using Autofac;

namespace Example.App
{
	public class SomeService
	{
		public string Blah { get { return "blah"; } }	
	}

	public class Index : Resource
	{
		private readonly SomeService _someService;

		public Index(SomeService someService)
		{
			_someService = someService;
		}

		public override IResourceResponse Get(ResourceRequestContext context)
		{
			return new TemplateResponse("~/index.haml");
		}
	}

	public class ExampleApplication : BebopApplication
	{
		public ExampleApplication()
		{
			Map<Index>("");

			Register(c => c.RegisterType<SomeService>().InstancePerDependency());
		}
	}
}
