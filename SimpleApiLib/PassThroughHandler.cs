using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApi
{
	internal class PassThroughHandler : DelegatingHandler
	{
		public PassThroughHandler()
		{
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage response;

			try
			{
				response = await base.SendAsync(request, cancellationToken);
			}
			catch (Exception e)
			{
				response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
			}

			return response;
		}
	}
}