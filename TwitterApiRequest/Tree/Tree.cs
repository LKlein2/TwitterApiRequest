using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterApiRequest.Tree
{
    class Tree
    {
        //private Node root { get; set; }
        //private int cont;

        //public bool Add(int Value)
        //{
        //    if (root == null)
        //    {
        //        root = new Node(Value);
        //        cont++;
        //        return true;
        //    }
        //    else
        //    {
        //        return Add_Sub(root, Value);
        //    }
        //}

        //private bool Add_Sub(Node Node, int Value)
        //{
        //    if (_comparer.Compare(Node.Value, Value) < 0)
        //    {
        //        if (Node.Right == null)
        //        {
        //            Node.Right = new Node(Value);
        //            cont++;
        //            return true;
        //        }
        //        else
        //        {
        //            return Add_Sub(Node.Right, Value);
        //        }
        //    }
        //    else if (_comparer.Compare(Node.Value, Value) > 0)
        //    {
        //        if (Node.Left == null)
        //        {
        //            Node.Left = new Node(Value);
        //            cont++;
        //            return true;
        //        }
        //        else
        //        {
        //            return Add_Sub(Node.Left, Value);
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void Print()
        //{
        //    Print(root, 4);
        //}

        //public void Print(Node p, int padding)
        //{
        //    if (p != null)
        //    {
        //        if (p.Right != null)
        //        {
        //            Print(p.Right, padding + 4);
        //        }
        //        if (padding > 0)
        //        {
        //            Console.Write(" ".PadLeft(padding));
        //        }
        //        if (p.Right != null)
        //        {
        //            Console.Write("/\n");
        //            Console.Write(" ".PadLeft(padding));
        //        }
        //        Console.Write(p.Value.ToString() + "\n ");
        //        if (p.Left != null)
        //        {
        //            Console.Write(" ".PadLeft(padding) + "\\\n");
        //            Print(p.Left, padding + 4);
        //        }
        //    }
        //}

    }
}
