using JsonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            //while (true)
            //{
                var teste = File.ReadAllText(@"C:\Users\lucas.klein\Desktop\1.json");

                var result = await TwitterRequest.GetTweets("GloboLixo", 100, null);
                var lista = JsonConvert.DeserializeObject<TwitterJson>(result);

                foreach (var item in lista.Statuses)
                {
                    Console.WriteLine(item.ToString() + "\n");
                }
            //}

            Console.ReadKey();
        }
    }
}
