using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] nums = new int[3] { 1, 2, 3 };

    void Start()
    {
        PermuteFunction(nums, 0);
    }

    private void PermuteFunction(int[] nums, int start)
    {
        if (start == nums.Length)
        {
            Debug.Log(string.Join(", ", nums));
            return;
        }

        for (int i = start; i < nums.Length; i++)
        {
            int temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;
            
            PermuteFunction(nums, start + 1);
            
            // 원상복구 (Backtracking)
            temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;
        }
    }
}