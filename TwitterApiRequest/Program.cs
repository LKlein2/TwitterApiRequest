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

            //string folderpath = @"C:\Users\lucas.klein\Source\Repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            //string file = @"twitter2.txt";
            //string indexFile = @"indice_id_tweet.txt";

            //SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            //si.ReadAndSearch("01185927377324515329");

            #endregion

            #region Search Hashtag

            string folderpath = @"C:\Users\lucas.klein\Source\Repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            string file = @"twitter2.txt";
            string indexFile = @"indice_screen_name.txt";

            SearchIndex si = new SearchIndex(folderpath, file, indexFile);
            si.ReadAndSearch("vieira_altair");

            #endregion

        }
    }
}
