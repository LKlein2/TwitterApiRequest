using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                    TheArray[index].Add(new RecordModel(line));
                }
            }
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
            Tree.Print();
        }

        public void SearchTree()
        {
        
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

        public int HashFunction(int date)
        {
            return date - 20191012;
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

        public static string DecodeData(byte[] data)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetString(data);
        }
    }
}
