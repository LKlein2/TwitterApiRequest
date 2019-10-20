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
        public List<IIndexable> Indexes{ get; set; }

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
                    Indexes.Add(new IndexTweetid { Key = line.Substring(0, KeySize - 1), Pos = Convert.ToInt64(line.Substring(KeySize)) });
                }
            }
        }

    }
}
