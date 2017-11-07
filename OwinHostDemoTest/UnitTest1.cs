using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using OwinSelfHostDemo;

namespace OwinHostDemoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Test200()
        {
            var code = await CallServer(async x =>
            {
                var response =await x.GetAsync("/");
                return response.StatusCode;
            });

            Assert.AreEqual(code,HttpStatusCode.OK);
            //using (var server = TestServer.Create<Startup>())
            //{
            //    HttpResponseMessage response = await server.HttpClient.GetAsync("/");
            //    Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            //    // TODO: Validate response
            //}
        }

        [TestMethod]
        public async Task Test200Content()
        {
            var body= await CallServer(async x =>
            {
                var response = await x.GetAsync("/");
                return  response.Content.ReadAsStringAsync().Result;
            });
            Assert.AreEqual("Hello World",body);
            //using (var server = TestServer.Create<Startup>())
            //{
            //    HttpResponseMessage response = await server.HttpClient.GetAsync("/");
            //    var content = await response.Content.ReadAsStringAsync();
            //    Assert.AreEqual("Hello World",content);
            //    // TODO: Validate response
            //}
        }

        [TestMethod]
        public async Task TestContentType()
        {
            var contenttype = await CallServer(async x =>
            {
                var response = await x.GetAsync("/BackGround1.png");
                return response.Content.Headers.ContentType.MediaType;
            });

            Assert.AreEqual("image/png", contenttype);
            //using (var server = TestServer.Create<Startup>())
            //{
            //    var response = await server.HttpClient.GetAsync("/BackGround1.png");
            //    var contenttype = response.Content.Headers.ContentType.MediaType;

            //    Assert.AreEqual("image/png",contenttype);
            //}
        }

        private async Task<T> CallServer<T>(Func<HttpClient,Task<T>> callback)
        {
            using (var server = TestServer.Create<Startup>())
            {
                return await callback(server.HttpClient);
            }
        }
    }
}
