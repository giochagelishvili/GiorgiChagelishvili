namespace Generic_Practices.Bonus
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T>? rootNode;

        public TreeNode<T> Find(T value)
        {
            if (rootNode == null)
                return null;
            
            return rootNode.Find(value);
        }

        public void Add(T value)
        {
            if (rootNode == null)
                rootNode = new TreeNode<T>(value);
            else
                rootNode.Add(value);
        }
    }
}
