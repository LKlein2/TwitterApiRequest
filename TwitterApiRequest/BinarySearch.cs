using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;
using System.Linq;
using System.IO;

namespace TwitterApiRequest
{
    public class BinarySearch
    {
        public static int IndexLineLength;

        public static List<IIndexable> Search(string target)
        {
            int mid, first = 0, last = FileLenght();

            while (first <= last)
            {
                mid = (first + last) / 2;
                int compare = String.Compare(target.ToUpper().Trim(), ReadIndexFile(mid).GetKey().ToUpper().Trim(), StringComparison.Ordinal);
                if (compare < 0)
                {
                    first = mid + 1;
                }
                else if (compare > 0)
                {
                    last = mid - 1;
                }
                else
                {
                    int prev = mid - 1;
                    List<IIndexable> returnList = new List<IIndexable>();
                    while (String.Compare(target.ToUpper().Trim(), ReadIndexFile(prev).GetKey().ToUpper().Trim(), StringComparison.Ordinal) == 0)
                    {
                        prev --;
                    }
                    prev ++;
                    while (String.Compare(target.ToUpper().Trim(), ReadIndexFile(prev).GetKey().ToUpper().Trim(), StringComparison.Ordinal) == 0)
                    {
                        returnList.Add(ReadIndexFile(prev));
                        prev ++;
                    }
                    return returnList;
                }
            }
           return null;
        }

        public static IIndexable ReadIndexFile(int offset)
        {
            string path = SearchIndex.FolderPath + @"\" + SearchIndex.IndexFileName;
            int KeySize;
            int PosSize;

            using (StreamReader reader = File.OpenText(path))
            {
                string[] cab = reader.ReadLine().Split(';');
                KeySize = Convert.ToInt32(cab[0]);
                PosSize = Convert.ToInt32(cab[1]);
            }

            IndexLineLength = KeySize + PosSize + 2;
            offset = IndexLineLength * offset;
            

            FileInfo file = new FileInfo(path);
            string text;

            using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
            {
                byte[] data;
                data = new byte[IndexLineLength];

                fileStream.Seek(offset, SeekOrigin.Begin);
                fileStream.Read(data, 0, IndexLineLength);
                text = SearchIndex.DecodeData(data);
            }
            return new IndexTweetid { Key = text.Substring(0, KeySize), Pos = Convert.ToInt64(text.Substring(KeySize)) };
        }

        public static int FileLenght()
        {
            string path = SearchIndex.FolderPath + @"\" + SearchIndex.IndexFileName;
            var qtdLinhas = File.ReadLines(path).Count();
            return qtdLinhas;
        }
    }
}
