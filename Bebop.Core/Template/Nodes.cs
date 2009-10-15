using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Bebop.Template
{
	public interface INode
	{
		string Apply(TemplateContext templateContext);
	}

	public sealed class VariableNode : INode
	{
		private string _variableName;

		public VariableNode(string variableName)
		{
			_variableName = variableName;
		}

		#region INode Members

		public string Apply(TemplateContext templateContext)
		{
			return templateContext[_variableName].ToString();
		}

		#endregion
	}

	public sealed class ContentNode : INode
	{

		#region INode Members

		public string Apply(TemplateContext templateContext)
		{
			throw new NotImplementedException();
		}

		#endregion
	}


	public sealed class LoopNode
	{
		private string _loopVariableName;
		private IEnumerable _enumerable;
		private ITemplate _innerTemplate;

		public LoopNode(
			string loopVariableName,
			IEnumerable enumerable,
			ITemplate innerTemplate)
		{
			_loopVariableName = loopVariableName;
			_enumerable = enumerable;
			_innerTemplate = innerTemplate;
		}

		public string Apply(TemplateContext templateContext)
		{
			StringBuilder nodeResponse = new StringBuilder();

			foreach (var i in _enumerable)
			{
				var context =
					templateContext.Union(
						new TemplateContext { { _loopVariableName, i } });

				nodeResponse.Append(_innerTemplate.Apply((TemplateContext)context));
			}

			return nodeResponse.ToString();
		}
	}
}
