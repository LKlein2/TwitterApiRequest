using System;
using System.Collections.Generic;
using System.Text;
using TwitterApiRequest.Indexes;

namespace TwitterApiRequest.Tree
{
    public class Tree
    {
        private Node root { get; set; }
        private int cont;

        public bool Add(IndexTweetid Value)
        {
            if (root == null)
            {
                root = new Node(Value);
                cont++;
                return true;
            }
            else if (_comparer(root.Value[0],Value) == 0)
            {
                root.Value.Add(Value);
                cont++;
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
                    cont++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.Right, Value);
                }
            }
            else if (_comparer(Node.Value[0], Value) < 0)
            {
                if (Node.Left == null)
                {
                    Node.Left = new Node(Value);
                    cont++;
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
                cont++;
                return true;
            }
        }

        public void Print()
        {
            Print(root, 4);
        }

        public void Print(Node p, int padding)
        {
            if (p != null)
            {
                if (p.Right != null)
                {
                    Print(p.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Value.ToString() + "\n ");
                if (p.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }

        public static int _comparer(IndexTweetid id1, IndexTweetid id2)
        {
            return String.Compare(id1.GetKey().ToUpper().Trim(), id2.GetKey().ToUpper().Trim(), StringComparison.Ordinal);
        }

    }
}
