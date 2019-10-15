using JsonClass;
using Newtonsoft.Json;
using System;
using System.IO;

namespace TwitterApiRequest
{
    class Program
    {
        static void Main(string[] args)
        {

            string json = File.ReadAllText(@"C:\Users\lucas.klein\Desktop\1.json");

            var result = JsonConvert.DeserializeObject<TwitterJson>(json);

            Console.WriteLine(result);
        }
    }
}
