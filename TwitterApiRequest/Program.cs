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
using TwitterApiRequest.Indexes;

namespace TwitterApiRequest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            #region Request e Write

            //await RequestsAndWriting.DoItAll();

            #endregion

            #region Search Twitter ID

            string folderpath = @"C:\Users\Lucas\Source\Repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            string file = @"twitter2.txt";
            string indexFile = @"indice.txt";

            SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            si.ReadAndSearch("01185927377324515329");

            #endregion

        }
    }
}
