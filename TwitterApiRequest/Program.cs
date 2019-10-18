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
            long id_max = 0;

            while (true)
            {
                var result = await TwitterRequest.GetTweets("CampeonatoBrasileiro", 100, null, id_max);
                var lista = JsonConvert.DeserializeObject<TwitterJson>(result);

                foreach (var item in lista.Statuses)
                {
                    FileWriter wf = new FileWriter();
                    wf.WriterOnFile(item.ToString());
                    Console.WriteLine(item.ToString() + "\n");

                    id_max = (item.Id);
                }

                Thread.Sleep(500);
            }

        }
    }
}
