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
        RecursiveInsert(Root, value);
    }
    private void RecursiveInsert(Node current, int value)
    {
        if (value < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = new Node(value);
            }
            else
            {
                RecursiveInsert(current.Left, value);
            }
        }
        if (value > current.Value)
        {
            if(current.Right == null)
            {
                current.Right = new Node(value);
            }
            else
            {
                RecursiveInsert(current.Right, value);
            }
        }
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
        if(node == null)
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
        if(Root == null)
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
        if(node.Left != null)
        {
            result += $"{node.Value} --> {node.Left.Value} \n";
            links++;
            result += ToMermaid(node.Left, ref links);
        }
        else
        {
            result += $"{node.Value} --> _phl{node.Value}[ ] \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phl{node.Value} fill:none,stroke:none,color:none \n";
            links++;
        }
        if(node.Right != null)
        {
            result += $"{node.Value} --> {node.Right.Value} \n";
            links++;
            result += ToMermaid(node.Right, ref links);
        }
        else
        {
            result += $"{node.Value} --> _phr{node.Value}[ ] \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phr{node.Value} fill:none, stroke:none,color:none \n";
            links++;
        }
        return result;
    }
}