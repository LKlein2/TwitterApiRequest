using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;

namespace TwitterApiRequest.Tree
{
    class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public List<IndexTweetid> Value { get; set; } = new List<IndexTweetid>();

        public Node(List<IndexTweetid> value)
        {
            this.Value = value;
        }
    }
}
