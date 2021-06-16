using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using REST.API;
using RestAPITesting.Utility;
using Selenium.DotNet.App;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestAPITesting
{
    [TestClass]
    public class ApiTester
    {
        private string _uri;
        private HttpClient _httpClient;
        IAssertWrapper _assertWrapper;

        [TestInitialize]
        public void CreateHttpClient()
        {
            _uri = "https://jsonplaceholder.typicode.com";
            _httpClient = new HttpClient();
            _assertWrapper = new MSTestAssertWrapper();
            Console.WriteLine("ClassInsitialze");
        }


        [TestMethod]
        public async Task GET_Direct_Request_Approach1()
        {
            //This test case runs Asynchronously.
            string resString = await _httpClient.GetStringAsync(_uri + "/users/1");

            User user = JsonConvert.DeserializeObject<User>(resString);

            _assertWrapper.AreEqual("Sincere@april.biz", user.email);
        }

        [TestMethod]
        public void GET_Direct_Request_Approach2()
        {
            //This test case runs Synchronously.
            Task<HttpResponseMessage> reshttp = _httpClient.GetAsync(_uri + "/users/1");

            Task<string> resString = reshttp.Result.Content.ReadAsStringAsync();

            User user = JsonConvert.DeserializeObject<User>(resString.Result);

            _assertWrapper.AreEqual("Sincere@april.biz", user.email);
        }         


        [TestMethod]
        public void GET_RestApi_Test()
        {
            Task<User> user = ApiEndPoints.GET_Using_GetStringAsync();
            _assertWrapper.AreEqual("Sincere@april.biz", user.Result.email);
        }

    }
}
