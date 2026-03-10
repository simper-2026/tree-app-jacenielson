public class Node
{
    int Value {private set; public get;}
    Node? Left {public set; public get;}
    Node? Right {public set; public get;}

    public Node(int value, Node? left=null, Node? right=null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}