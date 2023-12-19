namespace Generic_Practices.Bonus
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T nodeValue {  get; set; }
        public TreeNode<T>? leftNode {  get; set; }
        public TreeNode<T>? rightNode { get; set; }
        public TreeNode(T value)
        {
            nodeValue = value;
        }

        public void Add(T value)
        {
            // Adds value into right node if passed value is greater than or equal to nodeValue
            if (Comparer<T>.Default.Compare(value, nodeValue) >= 0)
            {
                if (rightNode == null)
                    rightNode = new TreeNode<T>(value);
                else
                    rightNode.Add(value);
            }
            else
            {
                if (leftNode == null)
                    leftNode = new TreeNode<T>(value);
                else
                    leftNode.Add(value);
            }
        }

        public TreeNode<T> Find(T value)
        {
            TreeNode<T> currentNode = this;

            while(currentNode != null)
            {
                // Return node if values are equal
                if (Comparer<T>.Default.Compare(value, currentNode.nodeValue) == 0)
                    return currentNode;
                // If value to find is greater than current node's value go to right node
                else if (Comparer<T>.Default.Compare(value, currentNode.nodeValue) > 0)
                    currentNode = currentNode.rightNode;
                // If value to find is less than current node's value go to left node
                else
                    currentNode = currentNode.leftNode;
            }

            return null;
        }
    }
}
