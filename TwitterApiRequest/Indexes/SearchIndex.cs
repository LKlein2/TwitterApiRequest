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

        public SearchIndex(string folderPath, string fileName, string indexFileName)
        {
            FolderPath = folderPath;
            FileName = fileName;
            IndexFileName = indexFileName;
        }

        public void ReadAndSearch(string id)
        {
            SearchWithIndex(id);
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

        public string GetData(string path, long offset)
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
