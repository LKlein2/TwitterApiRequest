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
            //return 0;

            #endregion

            string folderpath = @"C:\Users\Lucas\Source\Repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            //string folderpath = @"C:\Users\Eduardo\source\repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            string file = @"twitter2.txt";
            string indexFile;
            SearchIndex si;
            bool isTrue = true;

            while (isTrue)
            {

                Console.WriteLine("0 - Sair!");
                Console.WriteLine("1 - Busca sequencial indexada por ID tweet!");
                Console.WriteLine("2 - Busca sequencial indexada por Screen name!");
                Console.WriteLine("3 - Busca sequencial indexada por Hashtag!");
                Console.WriteLine("4 - Busca hash por data!");
                Console.WriteLine("5 - Busca Index Árvore!");
                var x = Console.ReadLine();
                Console.Clear();

                switch (x)
	            {
                    case "1":
                        #region Search Twitter ID
                        indexFile = @"indice_id_tweet.txt";

                        si = new SearchIndex(folderpath, file, indexFile);
                        si.SearchWithIndex("01186284419922976769");
                        break;
                        #endregion
                    case "2":
                        #region Search Screen Name
                        indexFile = @"indice_screen_name.txt";

                        si = new SearchIndex(folderpath, file, indexFile);
                        si.SearchWithIndex("ZettyCEC");
                        break;
                        #endregion
                    case "3":
                        #region Search HashTag
                        indexFile = @"indice2_hashtag_ordenado.txt";
                        si = new SearchIndex(folderpath, file, indexFile);

                        si.SearchWithIndex("B17");
                        break;
                    #endregion
                    case "4":
                        #region Search dataHash
                        si = new SearchIndex(folderpath, file);
                        si.ReadAndStore();
                        si.SearchHash(20191013);
                        break;
                    #endregion
                    case "5":
                        #region HashTag Tree
                        si = new SearchIndex(folderpath, file);
                        si.ReadAndStoreTree();
                        //si.SearchTree(20191013);
                        break;
                        #endregion
                default:
                        isTrue = false;
                        break;
	            }
            }
        }
    }
}
