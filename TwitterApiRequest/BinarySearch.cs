using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;
using System.Linq;

namespace TwitterApiRequest
{
    public class BinarySearch
    {
        public static IIndexable Search(List<IIndexable> indexes, string target)
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
                    return indexes[mid];
                }
            }
           return null;
        }
    }
}
