using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bebop
{
	public sealed class SimpleResponse : IViewResponse
	{
		private string _text;

		public SimpleResponse(string text)
		{
			_text = text;
		}

		#region IViewResponse Members

		public void Execute(HttpResponse response)
		{
			response.Write(_text);
		}

		#endregion
	}
}
