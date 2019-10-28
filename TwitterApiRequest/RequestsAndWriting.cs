using JsonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterApiRequest
{
    public class RequestsAndWriting
    {
        public static async Task DoItAll()
        {
            long id_max = 0;
            

            while (true)
            {
                var result = await TwitterRequest.GetTweets("Worlds2019", 100, null, id_max);
                var lista = JsonConvert.DeserializeObject<TwitterJson>(result);
                if (lista.Statuses.Count == 0)
                {
                    Console.WriteLine("ULTIMO ID ENCONTRADO: " + id_max);
                    break;
                }
                foreach (var item in lista.Statuses)
                {
                    //if (!item.Text.Substring(0,2).Equals("RT"))
                    //{
                        FileWriter wf = new FileWriter();
                        wf.WriterOnFile(item.ToString());
                    //}

                    id_max = (item.Id - 1);
                }

                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
