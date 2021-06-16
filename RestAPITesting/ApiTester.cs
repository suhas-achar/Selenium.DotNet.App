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
        private IAssertWrapper _assertWrapper;
        private IApiConnection _apiConnection;
        private ApiEndPoints _apiEndPoints;

        [TestInitialize]
        public void CreateHttpClient()
        {
            _uri = "https://jsonplaceholder.typicode.com";
            _assertWrapper = new MSTestAssertWrapper();
            _apiConnection = new HttpClientApiConnection();
            _apiEndPoints = new ApiEndPoints(_apiConnection);
        }


        /// <summary>
        /// This particaular test case (Asynchronously_Runnig_Test) runs Asynchronously. 
        /// Means, control go back to CLR once it reachere await
        /// Note the "async" keyword added to test method
        /// Alos the return type is "Task"
        /// </summary>
        /// <returns>Task</returns>
        [TestMethod]
        public async Task Asynchronously_Runnig_Test()
        {
            User user = await _apiEndPoints.GET_Using_GetAsync(_uri + "/users/1");

            _assertWrapper.AreEqual("Sincere@april.biz", user.email);
        }

        [TestMethod]
        public void GET_RestApi_Test_1()
        {
            Task<User> user = _apiEndPoints.GET_Using_GetAsync(_uri+"/users/1");

            _assertWrapper.AreEqual("Sincere@april.biz", user.Result.email);
        }

        [TestMethod]
        public void GET_RestApi_Test_2()
        {
            Task<User> user = _apiEndPoints.GET_Using_GetStringAsync(_uri + "/users/1");

            _assertWrapper.AreEqual("Sincere@april.biz", user.Result.email);
        }

    }
}
