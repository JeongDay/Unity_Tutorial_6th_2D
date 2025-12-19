using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T>
{
    public T data;
    public List<TreeNode<T>> children = new List<TreeNode<T>>();

    public TreeNode(T data)
    {
        this.data = data;
    }

    public void AddChild(TreeNode<T> node)
    {
        children.Add(node);
    }
}

public class StudyTree : MonoBehaviour
{
    void Start()
    {
        var rootNode = new TreeNode<string>("A");
        
        var bNode = new TreeNode<string>("B");
        var cNode = new TreeNode<string>("C");
        var dNode = new TreeNode<string>("D");

        rootNode.AddChild(bNode);
        rootNode.AddChild(cNode);
        rootNode.AddChild(dNode);
        
        var eNode = new TreeNode<string>("E");
        var fNode = new TreeNode<string>("F");
        
        bNode.AddChild(eNode);
        bNode.AddChild(fNode);
        
        var gNode = new TreeNode<string>("G");
        eNode.AddChild(gNode);

        PrintTreeNode(rootNode);
    }

    private void PrintTreeNode(TreeNode<string> node)
    {
        if (node.children.Count > 0)
        {
            PrintTreeNode(node.children[0]);
        }

        Debug.Log(node.data);


        for (int i = 1; i < node.children.Count; i++)
        {
            PrintTreeNode(node.children[i]);
        }
    }

    private void FindMax()
    {
        int[] array = new int[10] { 1, 10, 2, 5, 3, 1, 13, 4, 7, 9 };
        int maxValue = 0;
        
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                maxValue = array[0];
                continue;
            }

            if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
        }
    }
}