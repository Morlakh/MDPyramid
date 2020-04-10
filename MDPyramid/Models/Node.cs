namespace MDPyramid.Models
{
    public class Node
    {
        public int Number { get; }

        public Node Left { get; }

        public Node Right { get; }

        public bool IsNumberEven => Number % 2 == 0;

        public Node(int number, Node left = null, Node right = null)
        {
            Number = number;
            Left = left;
            Right = right;
        }
    }
}
