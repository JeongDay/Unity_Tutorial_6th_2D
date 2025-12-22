using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    public int[] values = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };

    private TreeNode root;
    private string result;

    void Start()
    {
        foreach (var v in values)
            root = Insert(root, v);

        PreOrder(root);
        Debug.Log($"전위 순회 : {result.TrimEnd(',')}");

        result = string.Empty;
        InOrder(root);
        Debug.Log($"중위 순회 : {result.TrimEnd(',')}");
        
        result = string.Empty;
        PostOrder(root);
        Debug.Log($"후위 순회 : {result.TrimEnd(',')}");
    }
    
    private TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.value)
            node.left = Insert(node.left, value);
        else
            node.right = Insert(node.right, value);

        return node;
    }

    // 전위 순회 : P -> L -> R
    private void PreOrder(TreeNode node)
    {
        if (node == null)
            return;

        result += $"{node.value} ,";
        PreOrder(node.left);
        PreOrder(node.right);
    }
    
    // 중위 순회 : L -> P -> R
    private void InOrder(TreeNode node)
    {
        if (node == null)
            return;

        InOrder(node.left);
        result += $"{node.value} ,";
        InOrder(node.right);
    }
    
    // 후위 순회 : L -> R -> P
    private void PostOrder(TreeNode node)
    {
        if (node == null)
            return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value} ,";
    }
}