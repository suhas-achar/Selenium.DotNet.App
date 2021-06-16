using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST.API
{
   public class HttpClientApiConnection : IApiConnection
    {
        private HttpClient _client;

        public HttpClientApiConnection()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GET_Async(string uri)
        {
            HttpResponseMessage resHttpResponseMsg = await _client.GetAsync(uri);
            Stream contentStream = await resHttpResponseMsg.Content.ReadAsStreamAsync();

            return contentStream;
        }

        public async Task<string> GET_String_Async(string uri)
        {           
            return await _client.GetStringAsync(uri);
        }
    }
}
