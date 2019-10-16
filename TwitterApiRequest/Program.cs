using JsonClass;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace TwitterApiRequest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var result = await TwitterRequest.GetTweets("GloboLixo", 100, null);
            var lista = JsonConvert.DeserializeObject<TwitterJson>(result);
            Console.ReadKey();
        }
    }
}
