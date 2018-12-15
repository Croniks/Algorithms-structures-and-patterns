using System;


namespace BinaryTree
{
    class Program
    {
        class Node : ICloneable
        {
            public int Value { get; private set; }

            public Node Parrent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int number) { Value = number; }

            public object Clone()
            {
                return new Node(this.Value);
            }
        }
        
        class BinaryTree
        {
            Node root;
            
            public void InsertNumber(int number)
            {
                Node node = new Node(number);

                if (root != null)
                {
                    Node current = root;
                    
                    while (true)
                    {
                        if (number == current.Value)
                        {
                            if (current.Right == null)
                            { 
                                current.Right = node;
                                node.Parrent = current;
                                break;
                            }
                            
                            node.Right = current;
                           
                            if (current.Parrent != null)
                            {
                                if (current.Parrent.Right == current)
                                    current.Parrent.Right = node;
                                else
                                    current.Parrent.Left = node;
                            }
                            else
                                root = node;

                            current.Parrent = node;

                            break;
                        }
                        else if(number > current.Value)
                        {
                            if (current.Right != null)
                            {
                                current = current.Right;
                                continue;
                            }
                            
                            current.Right = node;
                            node.Parrent = current;
                            break;
                        }
                        else
                        {
                            if (current.Left != null)
                            { 
                                current = current.Left;
                                continue;
                            }
                            
                            current.Left = node;
                            node.Parrent = current;
                            break;
                        }
                    }
                }
                else
                    root = node;
            }
            
            public void InsertNumber(int[] numbers)
            { 
                if(root == null)
                {
                    int indexRoot = numbers.Length / 2;
                    root = new Node(numbers[indexRoot]);
                    
                    for (int i=0; i < numbers.Length; i++)
                    { 
                        if(i != indexRoot)
                            InsertNumber(numbers[i]);
                    }
                }
                else
                    for (int i = 0; i < numbers.Length; i++)
                        InsertNumber(numbers[i]);
            }
            
            private Node SearchNodeByNumber(int number)
            {
                Node current = root;

                while (true)
                {
                    if (current == null) return null;

                    if (number < current.Value)
                    {
                        current = current.Left;
                        continue;
                    }
                    else if (number > current.Value)
                    {
                        current = current.Right;
                        continue;
                    }

                    return current;
                }
            }

            public Node GetCopyNodeByNumber(int number)
            {
                return (Node)SearchNodeByNumber(number)?.Clone();
            }
            
            public void DeleteNodeByNumber(int number)
            {
                Node node = SearchNodeByNumber(number);

                if(node == null) return;
                
                if(node.Left == null && node.Right == null)
                {
                    if(node.Parrent != null)
                    {
                        if(node.Parrent.Left == node) node.Parrent.Left = null;
                        else node.Parrent.Right = null;
                    }
                    else
                        root = null;
                }
                else if (node.Left != null && node.Right != null)
                {
                    Node current = node.Right;
                    
                    while(current.Left != null)
                        current = current.Left;

                    Node insertableNode = (Node)current.Clone();

                    insertableNode.Left = node.Left;
                    insertableNode.Right = node.Right;

                    // Вставка узла вместо удаляемого
                    if (node.Parrent != null)
                    {
                        if (node.Parrent.Left == node)
                            node.Parrent.Left = insertableNode;
                        else
                            node.Parrent.Right = insertableNode;
                    }
                    else
                        root = insertableNode;
                    
                    // Удаление вставляемого узла
                    if (insertableNode.Left == current)
                        insertableNode.Left = current.Right;
                    else if (insertableNode.Right == current)
                        insertableNode.Right = current.Right;
                    else if (current.Parrent.Left == current)
                        current.Parrent.Left = current.Right;
                    else if(current.Parrent.Right == current)
                        current.Parrent.Right = current.Right;
                }
                else
                {
                    if (node.Parrent.Left == node)
                        node.Parrent.Left = node.Left ?? node.Right;
                    else
                        node.Parrent.Right = node.Left ?? node.Right;
                }
            }
            
            public void PrintTree()
            { 
                void Print(Node node, int level)
                {
                    if(node == null) return;
                            
                    Print(node.Right, level + 1);   
                    
                    for (int i = 0; i < level; i++) Console.Write("   ");
                    Console.WriteLine(node.Value);
                    
                    Print(node.Left, level + 1);
                }
                
                Print(root, 1);
            }
        }
        
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();

            bt.InsertNumber(new int[]{ 2, 3, 4, 5, 7, 7, 8, 9 });
            
            bt.InsertNumber(6);
            bt.PrintTree();

            Console.WriteLine(new string('-', 30));

            Node node1 = bt.GetCopyNodeByNumber(7);
            Node node2 = bt.GetCopyNodeByNumber(2);
            Node node3 = bt.GetCopyNodeByNumber(9);
            Node node4 = bt.GetCopyNodeByNumber(1);

            Console.WriteLine(node1?.Value);
            Console.WriteLine(node2?.Value);
            Console.WriteLine(node3?.Value);
            Console.WriteLine(node4?.Value);

            Console.WriteLine(new string('=', 30));

            BinaryTree bt2 = new BinaryTree();

            bt2.InsertNumber(6);
            bt2.InsertNumber(5);
            bt2.InsertNumber(10);
            bt2.InsertNumber(8);
            bt2.InsertNumber(9);
            bt2.InsertNumber(12);
            bt2.InsertNumber(11);
            bt2.InsertNumber(13);

            bt2.PrintTree();

            Console.WriteLine(new string('-', 30));

            bt2.DeleteNodeByNumber(13);
            bt2.PrintTree();

            Console.ReadKey();
        }
    }
}
