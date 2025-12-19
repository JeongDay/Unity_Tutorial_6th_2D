using System.Collections.Generic;
using UnityEngine;

public class BoardStick : MonoBehaviour
{
    public enum StickType { Left = -7, Center = 0, Right = 7 }
    public StickType stickType;

    public Stack<GameObject> stack = new Stack<GameObject>();

    void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 링 선택
        {
            HanoiTower.isSelected = true;

            HanoiTower.selectedRing = stack.Pop();
        }
        else // 링 옮기기
        {
            if (stack.Count > 0)
            {
                GameObject peekRing = stack.Peek();
                int peekNumber = peekRing.GetComponent<Ring>().ringNumber;

                if (HanoiTower.selectedRing.GetComponent<Ring>().ringNumber > peekNumber)
                {
                    Debug.Log("<color=yellow>작은 링 위에 큰 링을 올릴 수 없습니다.</color>");
                    return;
                }
            }
            
            stack.Push(HanoiTower.selectedRing);
            
            HanoiTower.selectedRing.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            HanoiTower.selectedRing.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            
            HanoiTower.selectedRing.transform.position = new Vector3((int)stickType, 5f, 0);

            HanoiTower.isSelected = false;
            HanoiTower.selectedRing = null;
        }
    }

    public void PopRing()
    {
        
    }

    public bool CheckRing()
    {
        
    }

    public void PushRing()
    {
        
    }
}