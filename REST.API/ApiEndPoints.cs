using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST.API
{
    public class ApiEndPoints
    {
        private IApiConnection _apiConnection;
        public ApiEndPoints(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<User> GET_Using_GetStringAsync(string uri)
        {
            string resString = await _apiConnection.GET_String_Async(uri);

            User user = JsonConvert.DeserializeObject<User>(resString);

            return user;
        }

        public async Task<User> GET_Using_GetAsync(string uri)
        {
            Stream resStream = await _apiConnection.GET_Async(uri);
            StreamReader streamReader = new StreamReader(resStream);
            var jsonReader = new JsonTextReader(streamReader);

            JsonSerializer serializer = new JsonSerializer();

            User user = null;
            try
            {
                 user = serializer.Deserialize<User>(jsonReader);
                Console.WriteLine("User Email : " + user.email);
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("Invalid JSON.");
            }

            return user;
        }


        #region Orignal
        //public static async Task<User> GET_Using_GetStringAsync()
        //{
        //    var client = new HttpClient();

        //    string resString = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/1");

        //    User user = JsonConvert.DeserializeObject<User>(resString);

        //    return user;

        //}

        //public static async void GET_Using_GetAsync()
        //{
        //    var client = new HttpClient();

        //    Console.WriteLine("Http Request Intiating..");

        //    //GetAsync
        //    HttpResponseMessage resHttpResponseMsg = await client.GetAsync("https://jsonplaceholder.typicode.com/users/1");

        //    Console.WriteLine("Resonse Statuscode : " + resHttpResponseMsg.StatusCode);

        //    var contentStream = await resHttpResponseMsg.Content.ReadAsStreamAsync();

        //    var streamReader = new StreamReader(contentStream);
        //    var jsonReader = new JsonTextReader(streamReader);

        //    JsonSerializer serializer = new JsonSerializer();

        //    try
        //    {
        //        User user = serializer.Deserialize<User>(jsonReader);
        //        Console.WriteLine("User Email : " + user.email);
        //    }
        //    catch (JsonReaderException)
        //    {
        //        Console.WriteLine("Invalid JSON.");
        //    }

        //}

        //public static async void POST_Using_PostAsync()
        //{
        //    Login login = new Login();
        //    login.email = "eve.holt@reqres.in";
        //    login.password = "cityslicka";

        //    var json = JsonConvert.SerializeObject(login);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json"); //StringContent is sub class of HttpContent abstract class.

        //    HttpClient httpClient = new HttpClient();
        //    HttpResponseMessage response = await httpClient.PostAsync("https://reqres.in/api/login", data);




        //    // Using ReadAsStreamAsync()---------------------------------------------
        //    //Stream streamContent = await response.Content.ReadAsStreamAsync();
        //    //StreamReader streamReader = new StreamReader(streamContent);
        //    //JsonTextReader jsonReader = new JsonTextReader(streamReader);
        //    //JsonSerializer serializer = new JsonSerializer();

        //    //Token token = serializer.Deserialize<Token>(jsonReader);
        //    //Console.WriteLine("Response Recieved Token: " + token.token);

        //    //ReadAsStringAsync()----------------------------------------------------
        //    string strContent = await response.Content.ReadAsStringAsync();
        //    Token t = JsonConvert.DeserializeObject<Token>(strContent);

        //    Console.WriteLine("Response Recieved string content: " + strContent);
        //    Console.WriteLine("Response Recieved Token: " + t.token);
        //}

        #endregion


    }
}
