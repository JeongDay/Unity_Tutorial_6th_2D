using UnityEngine;

public class HeapSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log("정렬 전 : " + string.Join(", ", array));

        HSort(array);
        Debug.Log("정렬 후 : " + string.Join(", ", array));
    }

    private void HSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    // Heap 성질을 유지하기 위한 기능
    private void Heapify(int[] arr, int n, int i)
    {
        int max = i; // 부모 노드 인덱스
        int l = 2 * i + 1; // 왼쪽 자식 노드 인덱스
        int r = 2 * i + 2; // 오른쪽 자식 노드 인덱스
        
        if (l < n && arr[l] > arr[max])
            max = l;

        if (r < n && arr[r] > arr[max])
            max = r;

        if (max != i)
        {
            int temp = arr[i];
            arr[i] = arr[max];
            arr[max] = temp;

            Heapify(arr, n, max);
        }
    }
}