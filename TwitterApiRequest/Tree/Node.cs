using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;

namespace TwitterApiRequest.Tree
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public List<IndexTweetid> Value { get; set; } = new List<IndexTweetid>();

        public Node(IndexTweetid indexTweetId)
        {
            this.Value.Add(indexTweetId);
        }
    }
}
