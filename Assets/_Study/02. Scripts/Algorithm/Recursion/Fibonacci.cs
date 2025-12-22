using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    public int findIndex = 7; // 찾으려는 몇번째 값
    
    void Start()
    {
        int result = FibonacciFunction(findIndex);
        Debug.Log($"{findIndex}번째의 피보나치 수 : {result}");
        
        // 0 ~ findIndex 값까지 출력
        string str = "";
        for (int i = 0; i <= findIndex; i++)
        {
            str += FibonacciFunction(i) + " ";
        }

        Debug.Log(str);
    }

    private int FibonacciFunction(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}