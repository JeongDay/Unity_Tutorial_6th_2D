using System.Collections.Generic;
using UnityEngine;

public class BoardStick : MonoBehaviour
{
    public enum StickType { Left, Center, Right }
    public StickType stickType;
    
    public Stack<GameObject> stack = new Stack<GameObject>();

    void OnMouseDown()
    {
        Debug.Log($"현재 클릭한 막대기 위치는 {stickType}입니다.");
    }
}