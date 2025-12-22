using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    [SerializeField] private GameObject[] ringPrefabs;

    [SerializeField] private BoardStick[] sticks;
    
    public static GameObject selectedRing;
    public static bool isSelected;

    private int moveCount;

    public TextMeshProUGUI selectedText;
    public TextMeshProUGUI countText;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefabs[i]);

            ring.transform.position = new Vector3(-7f, 5f, 0); // Left Stick 위에 생성
            
            sticks[0].PushRing(ring);
            yield return new WaitForSeconds(1f);
        }

        moveCount = 0;
        countText.text = $"옮긴 횟수 : 0";
        yield return new WaitForSeconds(3f);

        StartCoroutine(HanoiRecursion((int)hanoiLevel, 0, 1, 2));
    }
    
    // private void HanoiRecursion(int n, int from, int temp, int to)
    // {
    //     if (n == 0)
    //         return;
    //
    //     if (n == 1)
    //     {
    //         Debug.Log($"{n}번 링을 {from}에서 {to}로 이동");
    //     }
    //     else
    //     {
    //         HanoiRecursion(n - 1, from, to, temp);
    //         Debug.Log($"{n}번 링을 {from}에서 {to}로 이동");
    //         
    //         HanoiRecursion(n - 1, temp, from, to);
    //     }
    // }

    IEnumerator HanoiRecursion(int n, int from, int temp, int to)
    {
        if (n == 0)
            yield break;
        
        if (n == 1)
        {
            Debug.Log($"{n}번 링을 {from}에서 {to}로 이동");
            MoveRing(from, to);
        }
        else
        {
            HanoiRecursion(n - 1, from, to, temp);
            
            Debug.Log($"{n}번 링을 {from}에서 {to}로 이동");
            MoveRing(from, to);
            
            HanoiRecursion(n - 1, temp, from, to);
        }
    }
    
    /// <summary>
    /// From Stack에서 데이터를 꺼내고 To Stack에게 데이터를 넣는 기능
    /// </summary>
    /// <param name="from">옮기려는 데이터가 있는 Stick</param>
    /// <param name="to">데이터를 넣으려는 Stick</param>
    private void MoveRing(int from, int to)
    {
        GameObject popRing = sticks[from].PopRing2();
        sticks[to].PushRing(popRing);
    }
    
    public void SetSelectedRing(string msg = null)
    {
        if (msg == null)
        {
            string newStr = selectedRing.name.Replace("(Clone)", "");
            selectedText.text = $"선택한 링 이름 : {newStr}";
        }
        else
        {
            selectedText.text = msg;
        }
    }

    public void AddMoveCount()
    {
        moveCount++;
        countText.text = $"옮긴 횟수 : {moveCount.ToString()}";
    }
}