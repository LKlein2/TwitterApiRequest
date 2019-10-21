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
        public static List<IIndexable> Search(List<IIndexable> indexes, string target)
        {
            int mid, first = 0, last = indexes.Count();

            while (first <= last)
            {
                mid = (first + last) / 2;
                int compare = String.Compare(target.ToUpper().Trim(), indexes[mid].GetKey().ToUpper().Trim(), StringComparison.Ordinal);
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
                    while (String.Compare(target.ToUpper().Trim(), indexes[prev].GetKey().ToUpper().Trim(), StringComparison.Ordinal) == 0)
                    {
                        prev--;
                    }
                    prev++;
                    while (String.Compare(target.ToUpper().Trim(), indexes[prev].GetKey().ToUpper().Trim(), StringComparison.Ordinal) == 0)
                    {
                        returnList.Add(indexes[prev]);
                        prev++;
                    }
                    return returnList;
                }
            }
           return null;
        }

        public IIndexable ReadIndexFile()
        {
            string path = SearchIndex.FolderPath + @"\" + SearchIndex.IndexFileName;

            using (StreamReader reader = File.OpenText(path))
            {
                string[] cab = reader.ReadLine().Split(';');
                int KeySize = Convert.ToInt32(cab[0]);
                int PosSize = Convert.ToInt32(cab[1]);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    return new IndexTweetid { Key = line.Substring(0, KeySize), Pos = Convert.ToInt64(line.Substring(KeySize)) };
                    //Indexes.Add(new IndexTweetid { Key = line.Substring(0, KeySize), Pos = Convert.ToInt64(line.Substring(KeySize)) });
                }
                return null;
            }
        }
    }
}
