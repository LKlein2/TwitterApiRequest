using JsonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TwitterApiRequest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await RequestsAndWriting.DoItAll();

        }
    }
}
