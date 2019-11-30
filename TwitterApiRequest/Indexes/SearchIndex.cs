using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TwitterApiRequest.Crypt;

namespace TwitterApiRequest.Indexes
{
    public class SearchIndex
    {
        public static string FolderPath { get; set; }
        public static string FileName { get; set; }
        public static string IndexFileName { get; set; }
        public static int LineLength { get; set; }

        public List<RecordModel>[] TheArray;
        public Tree.Tree Tree;

        public SearchIndex()
        {

        }

        public SearchIndex(string folderPath, string fileName)
        {
            FolderPath = folderPath;
            FileName = fileName;
        }

        public SearchIndex(string folderPath, string fileName, string indexFileName)
        {
            FolderPath = folderPath;
            FileName = fileName;
            IndexFileName = indexFileName;
        }

        public void ReadAndStore()
        {
            string path = FolderPath + @"\" + FileName;
            string line, date;
            int index;

            TheArray = new List<RecordModel>[15];
            for (int i = 0; i < TheArray.Length; i++)
            {
                TheArray[i] = new List<RecordModel>();
            }

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    date = line.Substring(20, 8);
                    index = HashFunction(Convert.ToInt32(date));
                    TheArray[index].Add(new RecordModel(line, true));
                }
            }
        }

        public void SerializeRecordModel()
        {
            string path = FolderPath + @"\" + FileName;
            string line;
            List<RecordModel> recordModel = new List<RecordModel>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    recordModel.Add(new RecordModel(line,true));
                }
            }
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\temp\teste.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, recordModel);
            }
        }

        public void Decrypt(string path)
        {
            string readText = File.ReadAllText(path);
            RecordModelMongo recordModel = JsonConvert.DeserializeObject<RecordModelMongo>(readText);
            string[] hastagArray = recordModel.HashTags.Split("#");
            string sReturn = "";

            if (hastagArray.Length != 0)
            { 
                for (int i = 1; i < hastagArray.Length; i++)
                {
                    sReturn += "#" + CesarEncryper.Deencrypt(hastagArray[i]) + "\n";
                }
            }
            Console.WriteLine(sReturn);
        }

        public void ReadAndStoreTree()
        {
            string path = FolderPath + @"\" + FileName;
            SearchIndex.GetLineLength(path);
            string line, hashatag;
            int index = 0, pos;
            Tree = new Tree.Tree();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    pos = LineLength * index;
                    line = reader.ReadLine();
                    hashatag = line.Substring(308, 280);
                    string[] lines = hashatag.Split('#');
                    for (int i = 1; i < lines.Length; i++)
                    {
                        Tree.Add(new IndexTweetid { Key = lines[i], Pos = pos });
                    }
                    index++;
                }
            }
        }

        public void SearchHash(int index)
        {
            index = HashFunction(index);
            try
            {
                if (TheArray[index].Count <= 0)
                {
                    Console.WriteLine("Não foi possível encontrar!");
                    return;
                }
                foreach (var item in TheArray[index])
                {
                    Console.WriteLine(item.ToString() + "\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível encontrar!");
            }
        }

        public void SearchHashNew(int index)
        {
            index = HashFunction(index);

            Hashtable times = new Hashtable();
            times["SKT"] = 0;
            times["FANATIC"] = 0;
            times["GRIFFIN "] = 0;
            times["FUNPLUS"] = 0;
            times["G2"] = 0;
            ArrayList al = new ArrayList(times.Keys);

            try
            {
                if (TheArray[index].Count <= 0)
                {
                    Console.WriteLine("Não foi possível encontrar!");
                    return;
                }
                foreach (var item in TheArray[index])
                {
                    foreach (var k in al)
                    {
                        if (item.Tweet.ToUpper().Contains(k.ToString()))
                        {
                            int teste = Convert.ToInt32(times[k]) + 1;
                            times[k] = teste;
                        }
                    }
                }
        }
        catch (Exception e)
        {
            Console.WriteLine("Não foi possível encontrar!");
        }
            string time = "";
            int maior = 0;
            foreach (var k in al)
            {
                if (Convert.ToInt32(times[k]) > maior)
                {
                    time = k.ToString();
                    maior = Convert.ToInt32(times[k]);
                }
                Console.Write($"Time {k} possui {times[k]} menções!\n");
            }
            Console.Write("\n");
            Console.WriteLine($"O time mais comentado foi {time} com {maior} menções!");
            Console.Write("\n\n");
        }

        public int HashFunction(int date)
        {
            return date - 20191020;
        }

        public void SearchWithIndex(string id)
        {
            string path = FolderPath + @"\" + FileName;
            List<IIndexable> index = BinarySearch.Search(id);


            GetLineLength(path);
            if (index != null)
            {
                foreach (var item in index)
                {
                    var rm = new RecordModel(GetData(path, item.GetPos()));
                    Console.WriteLine(rm.ToString() + "\n\n");
                }                
            } 
            else
            {
                Console.WriteLine("Id não encontrado");
            }
        }

        public static void GetLineLength(string path)
        {
            string line;
            using (StreamReader reader = new StreamReader(path))
            {
                line = reader.ReadLine();
                line = reader.ReadLine();
                if (line != null)
                {
                    LineLength = line.Length + 2;
                }
            }
        }

        public static string GetData(string path, long offset)
        {
            FileInfo file = new FileInfo(path);
            string text;

            using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
            {
                byte[] data;
                data = new byte[LineLength];

                fileStream.Seek(offset, SeekOrigin.Begin);
                fileStream.Read(data, 0, LineLength);
                text = DecodeData(data);
            }
            return text;
        }

        public void SearchTree(String value)
        {
            Tree.SearchTree(Tree.root, value);
        }


        public static string DecodeData(byte[] data)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetString(data);
        }
    }
}
