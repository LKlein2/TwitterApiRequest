using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterApiRequest.Indexes
{
    public class IndexTweetid : IIndexable
    {
        public string Key { get; set; }
        public int Pos { get; set; }
        public string GetKey()
        {
            return Key;
        }

        public int GetPos()
        {
            return Pos;
        }
    }
}
