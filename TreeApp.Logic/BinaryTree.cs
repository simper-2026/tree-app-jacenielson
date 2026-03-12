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
        if (value > current.Valye)
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
        return @"graph TD
         5 ---> 2";
    }
}