using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using REST.API;
using RestAPITesting.Utility;
using Selenium.DotNet.App;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestAPITesting
{
    /// <summary>
    /// https://www.automatetheplanet.com/mstest-cheat-sheet/
    /// </summary>
    [TestClass]
    public class ApiTester
    {
        private static string _uri;
        private static IAssertWrapper _assertWrapper;
        private static IApiConnection _apiConnection;
        private static ApiEndPoints _apiEndPoints;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            /***** Executes once before the test run. (Optional)  *****/
            Debug.WriteLine("***** 1. [AssemblyInitialize] *****");

        }

        /// <summary>
        /// For [ClassInitialize] to work, the method shouble static, public and should take one parametert "TestContext".
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void CreateHttpClient(TestContext context)
        {
            /***** Executes once for the test class. (Optional) *****/
            Debug.WriteLine("***** 2. [ClassInitialize] *****");

            _uri = "https://jsonplaceholder.typicode.com";
            _assertWrapper = new MSTestAssertWrapper();
            _apiConnection = new HttpClientApiConnection();
            _apiEndPoints = new ApiEndPoints(_apiConnection);
        }

        [TestInitialize]
        public void Setup()
        {
            /*****  Runs before each test. (Optional) *****/
            Debug.WriteLine("***** 3. [TestInitialize] *****");
        }

        [TestCleanup]
        public void TearDown()
        {
            /***** Runs after each test. (Optional) *****/
            Debug.WriteLine("***** 4. [TestCleanup] *****");
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            /***** Runs once after all tests in this class are executed. (Optional) *****/
            /***** Not guaranteed that it executes instantly after all tests from the class.  *****/
            Debug.WriteLine("***** 5. [ClassCleanup] *****");
        }

        

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            /*****  Executes once after the test run. (Optional) *****/
            Debug.WriteLine("***** 6. [AssemblyCleanup] *****");
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
            Task<User> user = _apiEndPoints.GET_Using_GetAsync(_uri + "/users/1");

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
