using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Bebop.Template
{
	public sealed class TemplateContext : Dictionary<string, object>
	{
		public TemplateContext()
			: base()
		{
		}

		public TemplateContext(TemplateContext context)
			: base(context)
		{
		}
	}

	public interface ITemplate
	{
		string Apply(TemplateContext context);
	}

	public sealed class BebopTemplate : ITemplate
	{
		private IEnumerable<INode> _nodes;

		public BebopTemplate(IEnumerable<INode> nodes)
		{
			_nodes = nodes;
		}

		#region ITemplate Members

		public string Apply(TemplateContext context)
		{
			var response = new StringBuilder();

			foreach (var node in _nodes)
			{
				response.Append(node.Apply(context));
			}

			return response.ToString();
		}

		#endregion
	}

	public interface ITemplateEngine
	{
		ITemplate CreateFromStream(Stream stream);
	}

	public sealed class BebopTemplateEngine : ITemplateEngine
	{
		#region ITemplateEngine Members

		public ITemplate CreateFromStream(Stream stream)
		{
			throw new NotImplementedException();
		}

		#endregion
	}

}
