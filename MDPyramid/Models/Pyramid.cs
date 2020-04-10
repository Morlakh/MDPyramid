using System.Collections.Generic;
using System.Linq;

namespace MDPyramid.Models
{
    public class Pyramid
    {
        public Node RootNode { get; private set; }
        
        public int Depth { get; set; }

        public int Max { get; private set; } = 0;

        public int[] MaxPath { get; private set; }

        public Pyramid(string[] lines)
        {
            var nodeList = new List<Node>();
            var childrenList = new List<Node>();

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                var numbers = lines[i].Split(' ');
                var tempList = new List<Node>();

                for (int j = 0; j < numbers.Length; j++)
                {
                    var node = new Node(
                        int.Parse(numbers[j]),
                        childrenList.ElementAtOrDefault(j),
                        childrenList.ElementAtOrDefault(j + 1));

                    tempList.Add(node);
                }

                nodeList.AddRange(tempList);
                childrenList = tempList;
            }

            RootNode = nodeList.Last();
            Depth = lines.Length;
        }

        public void Calculate()
        {
            var arr = new int[Depth];
            Traverse(RootNode, 0, arr, 0, !RootNode.IsNumberEven);
        }

        private void Traverse(
            Node node,
            int sumSoFar,
            int[] pathSoFar,
            int pathLength,
            bool isEven)
        {
            if (node == null)
            {
                return;
            }

            var isNodeEven = node.IsNumberEven;
            if (isNodeEven == isEven)
            {
                return;
            }

            sumSoFar += node.Number;
            pathSoFar[pathLength] = node.Number;
            pathLength++;

            // No need to check for right, we know that pyramid nodes can't have one child
            if (node.Left == null)
            {
                if (sumSoFar > Max)
                {
                    Max = sumSoFar;
                    MaxPath = pathSoFar;
                }
            }

            Traverse(node.Left, sumSoFar, pathSoFar, pathLength, isNodeEven);
            Traverse(node.Right, sumSoFar, pathSoFar, pathLength, isNodeEven);
        }
    }
}
