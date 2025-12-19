using System.Collections.Generic;
using UnityEngine;

public class BoardStick : MonoBehaviour
{
    public enum StickType { Left = -7, Center = 0, Right = 7 }
    public StickType stickType;

    private HanoiTower hanoiTower;

    public Stack<GameObject> stack = new Stack<GameObject>();

    void Start()
    {
        hanoiTower = transform.parent.GetComponent<HanoiTower>();
    }

    void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 링 선택
            PopRing();
        else // 링 옮기기
            PushRing(HanoiTower.selectedRing);
    }

    public void PopRing()
    {
        if (stack.Count > 0)
        {
            HanoiTower.isSelected = true;
            HanoiTower.selectedRing = stack.Pop();
            hanoiTower.SetSelectedRing();
        }
    }

    public void PushRing(GameObject ring)
    {
        if (!CheckRing(ring))
            return;
        
        ring.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ring.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        ring.transform.position = new Vector3((int)stickType, 5f, 0);

        HanoiTower.isSelected = false;
        HanoiTower.selectedRing = null;
        
        hanoiTower.AddMoveCount();
        stack.Push(ring);

        if (CompletedHanoiTower())
        {
            Debug.Log("<color=green>하노이 타워 완료!</color>");
        }
    }

    public bool CheckRing(GameObject ring)
    {
        if (stack.Count > 0)
        {
            GameObject peekRing = stack.Peek();
            int peekNumber = peekRing.GetComponent<Ring>().ringNumber;

            if (ring.GetComponent<Ring>().ringNumber > peekNumber)
            {
                Debug.Log("<color=yellow>작은 링 위에 큰 링을 올릴 수 없습니다.</color>");
                return false;
            }
        }

        return true;
    }

    private bool CompletedHanoiTower()
    {
        if (stickType == StickType.Right)
        {
            if (stack.Count == (int)hanoiTower.hanoiLevel)
                return true;
        }

        return false;
    }
}