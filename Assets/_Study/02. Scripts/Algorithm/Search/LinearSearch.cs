using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    public int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int target = 7;

    void Start()
    {
        LSearch(array, target);
    }

    private void LSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                Debug.Log($"{target}은 인덱스 넘버 {i}번째에 있습니다.");
            }
        }
    }
}