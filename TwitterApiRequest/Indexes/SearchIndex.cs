using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TwitterApiRequest.Indexes
{
    public class SearchIndex
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public string IndexFileName { get; set; }
        public int LineLength { get; set; }
        public List<IIndexable> Indexes { get => indexes; set => indexes = value; }
        private List<IIndexable> indexes = new List<IIndexable>();

        public SearchIndex(string folderPath, string fileName, string indexFileName)
        {
            this.FolderPath = folderPath;
            this.FileName = fileName;
            this.IndexFileName = indexFileName;
        }

        public void ReadAndSearch(string id)
        {
            ReadIndexFile();
            SearchWithIndex(id);
        }

        public void ReadIndexFile()
        {
            string path = FolderPath + @"\" + IndexFileName;

            using (StreamReader reader = File.OpenText(path))
            {
                string[] cab = reader.ReadLine().Split(';');
                int KeySize = Convert.ToInt32(cab[0]);
                int PosSize = Convert.ToInt32(cab[1]);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Indexes.Add(new IndexTweetid { Key = line.Substring(0, KeySize), Pos = Convert.ToInt64(line.Substring(KeySize))});
                }
            }
        }

        public void SearchWithIndex(string id)
        {
            string path = FolderPath + @"\" + FileName;
            GetLineLength(path);
            IIndexable index = BinarySearch.Search(Indexes, id);
            if (index != null)
            {
                string line = GetData(path, index.GetPos());
                
            } 
            else
            {
                Console.WriteLine("Id não encontrado");
            }
        }

        public void GetLineLength(string path)
        {
            string line;
            using (StreamReader reader = new StreamReader(path))
            {
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

        private static string DecodeData(byte[] data)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetString(data);
        }
    }
}
