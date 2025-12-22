using UnityEngine;

public class Factorial : MonoBehaviour
{
    public int n = 5;
    
    void Start()
    {
        int result = FactorialFunction(n);
        
        Debug.Log(result);
    }
    
    private int FactorialFunction(int n)
    {
        if (n == 0)
            return 1;
        else
            return n * FactorialFunction(n - 1);
    }
}