public class Node
{
    public int Value {private set; get;}
    public Node? Left { set;  get;}
    public Node? Right { set; get;}

    public Node(int value, Node? left=null, Node? right=null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}