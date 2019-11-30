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
            //Console.ReadKey();

            #endregion

            //string folderpath = @"C:\Users\Lucas\Source\Repos\TwitterApiRequest\TwitterApiRequest\DataFile";
            string folderpath = @"C:\Users\Lucas\Source\Repos\LKlein2\TwitterApiRequest\TwitterApiRequest\DataFile";
            string file = @"twitter2.txt";
            string indexFile;
            SearchIndex si;
            bool isTrue = true;

            while (isTrue)
            {
                Console.WriteLine("\n ********** M E N U **********");
                Console.WriteLine("0 - Sair!");
                Console.WriteLine("1 - Busca sequencial indexada por ID tweet!");
                Console.WriteLine("2 - Busca sequencial indexada por Screen name!");
                Console.WriteLine("3 - Busca sequencial indexada por Hashtag!");
                Console.WriteLine("4 - Busca hash por data!");
                Console.WriteLine("5 - Busca Index Árvore!");
                Console.WriteLine("6 - Time mais comentado por data!");
                Console.WriteLine("7 - Gerar Json criptografado!");
                Console.WriteLine("8 - Gerar querys MongoDB!");
                Console.WriteLine("9 - Descriptografar hastags!");
                var x = Console.ReadLine();
                Console.Clear();

                switch (x)
	            {
                    case "1":
                        #region Search Twitter ID
                        indexFile = @"indice_id_tweet.txt";
                        si = new SearchIndex(folderpath, file, indexFile);
                        Console.WriteLine("Digite um indice: \n");
                        var texto = Console.ReadLine();
                        si.SearchWithIndex(texto);
                        break;
                        #endregion
                    case "2":
                        #region Search Screen Name
                        indexFile = @"indice_screen_name.txt";
                        si = new SearchIndex(folderpath, file, indexFile);
                        Console.WriteLine("Digite um nome: \n");
                        texto = Console.ReadLine();
                        si.SearchWithIndex(texto);
                        break;
                        #endregion
                    case "3":
                        #region Search HashTag
                        indexFile = @"indice2_hashtag_ordenado.txt";
                        si = new SearchIndex(folderpath, file, indexFile);
                        Console.WriteLine("Digite uma hashtag: \n");
                        texto = Console.ReadLine();
                        si.SearchWithIndex(texto);
                        break;
                        #endregion
                    case "4":
                        #region Search dataHash
                        si = new SearchIndex(folderpath, file);
                        si.ReadAndStore();
                        Console.WriteLine("Digite uma data: \n");
                        texto = Console.ReadLine();
                        si.SearchHash(Convert.ToInt32(texto));
                        break;
                        #endregion
                    case "5":
                        #region HashTag Tree
                        si = new SearchIndex(folderpath, file);
                        si.ReadAndStoreTree();
                        Console.WriteLine("Digite uma hashtag: \n");
                        texto = Console.ReadLine();
                        si.SearchTree(texto);
                        break;
                        #endregion
                    case "6":
                        #region HashTag Tree
                        si = new SearchIndex(folderpath, file);
                        si.ReadAndStore();
                        Console.WriteLine("Digite uma data: \n");
                        texto = Console.ReadLine();
                        si.SearchHashNew(Convert.ToInt32(texto));
                        break;
                        #endregion
                    case "7":
                        si = new SearchIndex(folderpath, file);
                        si.SerializeRecordModel();
                        break;
                    case "8":
                        Console.WriteLine("Digite uma data (yyyy-mm-dd): \n");
                        texto = Console.ReadLine();
                        Console.WriteLine("db.getCollection('TwitterDb').count( { $and: [ { Tweet: /.* G2.*/ i }, { Date: /.* " + texto + ".*/ } ] } )");
                        Console.WriteLine("db.getCollection('TwitterDb').count( { $and: [ { Tweet: /.* SKT.*/ i }, { Date: /.* " + texto + ".*/ } ] } )");
                        Console.WriteLine("db.getCollection('TwitterDb').count( { $and: [ { Tweet: /.* FNATIC.*/ i }, { Date: /.* " + texto + ".*/ } ] } )");
                        Console.WriteLine("db.getCollection('TwitterDb').count( { $and: [ { Tweet: /.* FUNPLUS.*/ i }, { Date: /.* " + texto + ".*/ } ] } )");
                        Console.WriteLine("db.getCollection('TwitterDb').count( { $and: [ { Tweet: /.* GRIFFIN.*/ i }, { Date: /.* " + texto + ".*/ } ] } )");
                        break;
                    case "9":
                        Console.WriteLine("Digite o caminho do arquivo: \n");
                        texto = Console.ReadLine();
                        si = new SearchIndex();
                        si.Decrypt(texto);
                        break;
                    default:
                        isTrue = false;
                        break;
	            }
            }
        }
    }
}
