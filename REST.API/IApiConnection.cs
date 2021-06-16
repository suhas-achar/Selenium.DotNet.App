using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.API
{
    public interface IApiConnection
    {
        Task<string> GET_String_Async(string uri);
        Task<Stream> GET_Async(string uri);

    }
}
