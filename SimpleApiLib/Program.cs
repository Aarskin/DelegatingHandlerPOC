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
		public void Test1()
		{
			// Create HttpCient and make a request to api/values 
			HttpClient client = new HttpClient();

			var response = client.GetAsync(baseAddress + "api/values").Result;

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}

		[TearDown]
		public void TearDown()
		{
			handle.Dispose();
		}
	}
}
