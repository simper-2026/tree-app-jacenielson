public class BinaryTree
{
    public Node? Root { get; private set; }
    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }
        Root = RecursiveInsert(Root, value);
    }
    private Node RecursiveInsert(Node current, int value)
    {
        if (value < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = new Node(value);
            }
            else
            {
                current.Left = RecursiveInsert(current.Left, value);
            }
        }
        if (value > current.Value)
        {
            if (current.Right == null)
            {
                current.Right = new Node(value);
            }
            else
            {
                current.Right = RecursiveInsert(current.Right, value);
            }
        }
        return Balance(current);
    }
    public string InOrder()
    {
        if (Root == null)
        {
            return string.Empty;
        }
        List<int> values = new List<int>();
        InOrderRecursive(Root, values);

        return string.Join(", ", values);
    }

    private void InOrderRecursive(Node? node, List<int> values)
    {
        if (node == null)
        {
            return;
        }
        InOrderRecursive(node.Left, values);
        values.Add(node.Value);
        InOrderRecursive(node.Right, values);
    }
    public int Height()
    {
        return RecursiveHeight(Root);
    }
    private int RecursiveHeight(Node? node)
    {
        if (node == null)
        {
            return 0;
        }
        int leftHeight = RecursiveHeight(node.Left);
        int rightHeight = RecursiveHeight(node.Right);
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    public string ToMermaid()
    {
        int links = 0;
        if (Root == null)
        {
            return "graph TD;\n";
        }
        else if (Root.Left == null && Root.Right == null)
        {
            return $"graph TD;\n{Root.Value}\n";
        }
        return $"graph TD;\n{ToMermaid(Root, ref links)}\n";
    }
    private string ToMermaid(Node? node, ref int links)
    {
        if (node == null || node.Right == null && node.Left == null)
        {
            return string.Empty;
        }
        string result = string.Empty;
        if (node.Left != null)
        {
            result += $"{node.Value}[{node.Value} h:{RecursiveHeight(node)}]  --> {node.Left.Value}[{node.Left.Value} h:{RecursiveHeight(node.Left)} ] \n";
            links++;
            result += ToMermaid(node.Left, ref links);
        }
        else
        {
            result += $"{node.Value}[{node.Value} h:{RecursiveHeight(node)}] --> _phl{node.Value} \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phl{node.Value} fill:none,stroke:none,color:none \n";
            links++;
        }
        if (node.Right != null)
        {
            result += $"{node.Value}[{node.Value} h:{RecursiveHeight(node)}] --> {node.Right.Value}[{node.Right.Value} h:{RecursiveHeight(node.Right)} ] \n";
            links++;
            result += ToMermaid(node.Right, ref links);
        }
        else
        {
            result += $"{node.Value}[{node.Value} h:{RecursiveHeight(node)}] --> _phr{node.Value}[ ] \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phr{node.Value} fill:none, stroke:none,color:none \n";
            links++;
        }
        return result;
    }
    private Node RotateRight(Node z)
    {
        Node y = z.Left;
        Node t3 = y.Right;  
        y.Right = z;
        z.Left = t3;
        return y;               
    }
    private Node RotateLeft(Node z)
    {
        Node y = z.Right;
        Node t2 = y.Left;
        y.Left = z;
        z.Right = t2;
        return y;
    }
    private Node Balance(Node node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
            }
            return RotateRight(node);
        }
        if(balanceFactor < -1)
        {
            if(GetBalanceFactor(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
            }
            return RotateLeft(node);
        }
        return node;
    }
    private int GetBalanceFactor(Node? node)
    {
        if (node == null)
        {
            return 0;
        }
        return RecursiveHeight(node.Left)-RecursiveHeight(node.Right);
    }



}