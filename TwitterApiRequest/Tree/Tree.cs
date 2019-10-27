using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;

namespace TwitterApiRequest.Tree
{
    public class Tree
    {
        public Node root { get; set; }

        public bool Add(IndexTweetid Value)
        {
            if (root == null)
            {
                root = new Node(Value);
                return true;
            }
            else if (_comparer(root.Value[0],Value) == 0)
            {
                root.Value.Add(Value);
                return true;
            }
            else
            {
                return Add_Sub(root, Value);
            }
        }

        private bool Add_Sub(Node Node, IndexTweetid Value)
        {
            if (_comparer(Node.Value[0], Value) < 0)
            {
                if (Node.Right == null)
                {
                    Node.Right = new Node(Value);
                    return true;
                }
                else
                {
                    return Add_Sub(Node.Right, Value);
                }
            }
            else if (_comparer(Node.Value[0], Value) > 0)
            {
                if (Node.Left == null)
                {
                    Node.Left = new Node(Value);
                    return true;
                }
                else
                {
                    return Add_Sub(Node.Left, Value);
                }
            }
            else
            {
                Node.Value.Add(Value);
                return true;
            }
        }

        public void SearchTree(Node Node, String value)
        {
            if(Node != null)
            {
                this.SearchTree(Node.Left, value);
                if (Node.Value[0].GetKey().ToUpper().Trim().Equals(value.ToUpper().Trim()))
                {
                    foreach (var item in Node.Value)
                    {
                        Console.WriteLine(item.GetKey());
                    }
                    return;
                }
                this.SearchTree(Node.Right, value);
            }
        }



        public static int _comparer(IndexTweetid id1, IndexTweetid id2)
        {
            return String.Compare(id1.GetKey().ToUpper().Trim(), id2.GetKey().ToUpper().Trim(), StringComparison.Ordinal);
        }

    }
}
