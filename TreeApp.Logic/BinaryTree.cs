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
        return "";
    }
    public int Height()
    {
        return 0;
    }
    public string ToMermaid()
    {
        if(Root == null)
        {
            return "graph TD;\n";
        }
        else if (Root.Left == null && Root.Right == null)
        {
            return $"graph TD;\n{Root.Value}\n";
        }
        return $"graph TD;\n{ToMermaid(Root)}\n";
    }
    private string ToMermaid(Node? node)
    {
        if (node == null || node.Right == null && node.Left == null)
        {
            return string.Empty;
        }
        string result = string.Empty;
        if(node.Left != null)
        {
            result += $"{node.Value} --> {node.Left.Value} \n";
            result += ToMermaid(node.Left);
        }
        else
        {
            result += $"{node.Value} --> _phl{node.Value}[ ] \n";
            result += "linkStyle 1 stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phl{node.Value} fill:none,stroke:none,color:none \n";
        }
        if(node.Right != null)
        {
            result += $"{node.Value} --> {node.Right.Value} \n";
            result += ToMermaid(node.Right);
        }
        else
        {
            result += $"{node.Value} --> _phr{node.Value}[ ] \n";
            result += "linkStyle 1 stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phr{node.Value} fill:none, stroke:none,color:none \n";
        }
        return result;
    }
}