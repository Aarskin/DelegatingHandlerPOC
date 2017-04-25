using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi
{
	[TestFixture]
	public class Program
	{
		static IDisposable handle;
		static string baseAddress = "http://localhost:9000/";

		[SetUp]
		public void SetUp()
		{
			// Start OWIN host 
			handle = WebApp.Start<Startup>(url: baseAddress);
		}

		[Test]
		public void TestGet()
		{
			HttpClient client = new HttpClient();
			HttpRequestMessage msq = new HttpRequestMessage()
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(baseAddress + "api/values")
			};

			var response = client.SendAsync(msq).Result;

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public void TestPost()
		{
			HttpClient client = new HttpClient();
			HttpRequestMessage msq = new HttpRequestMessage()
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(baseAddress + "api/values")
			};

			var response = client.SendAsync(msq).Result;

			Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
		}


		[TearDown]
		public void TearDown()
		{
			handle.Dispose();
		}
	}
}
