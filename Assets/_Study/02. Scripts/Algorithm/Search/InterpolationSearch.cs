using UnityEngine;

public class InterpolationSearch : MonoBehaviour
{
    private int[] array = { 1, 3, 6, 7, 9, 13, 15, 17 };
    
    public int target = 15;

    void Start()
    {
        int result = ISearch(array, target);

        Debug.Log($"{target}은 인덱스 {result}번째에 있습니다.");
    }

    private int ISearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right && target >= arr[left] && target <= arr[right])
        {
            if (arr[left] == arr[right])
            {
                if (arr[left] == target)
                    return left;
                else
                    break;
            }
            
            int mid = left + ((right - left) * (target - arr[left])) / (arr[right] - arr[left]);

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return -1;
    }
}