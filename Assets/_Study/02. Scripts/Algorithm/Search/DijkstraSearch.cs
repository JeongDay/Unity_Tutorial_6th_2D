using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {
      // 0  1  2  3  4  5
        {0, 1, 2, 0, 4, 0,}, // 0
        {1, 0, 0, 0, 0, 8,}, // 1
        {2, 0, 0, 3, 0, 0,}, // 2
        {0, 0, 3, 0, 0, 0,}, // 3
        {4, 0, 0, 0, 0, 2,}, // 4
        {0, 8, 0, 0, 2, 0,}, // 5
    };
}