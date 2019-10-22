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
        //static async Task Main(string[] args)
        static void Main(string[] args)
        {
            #region Request e Write

            //await RequestsAndWriting.DoItAll();

            #endregion

            string folderpath = @"C:\Users\Lucas\Source\Repos\LKlein2\TwitterApiRequest\TwitterApiRequest\DataFile";

            #region Search Twitter ID
            //string file = @"twitter2.txt";
            //string indexFile = @"indice_id_tweet.txt";

            //SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            //si.ReadAndSearch("01186284419922976769");
            #endregion

            #region Search Screen Name
            //string file = @"twitter2.txt";
            //string indexFile = @"indice_screen_name.txt";

            //SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            //si.ReadAndSearch("ZettyCEC");
            #endregion

            #region Search HashTag
            //string file = @"twitter2.txt";
            //string indexFile = @"indice2_hashtag_ordenado.txt";

            //SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            //si.ReadAndSearch("B17");
            #endregion

            Console.ReadKey();

        }
    }
}
