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

        countText.text = $"옮긴 횟수 : 0";
    }

    public void SetSelectedRing()
    {
        string newStr = selectedRing.name.Replace("(Clone)", "");
        selectedText.text = $"선택한 링 이름 : {newStr}";
    }

    public void AddMoveCount()
    {
        moveCount++;
        countText.text = $"옮긴 횟수 : {moveCount.ToString()}";
    }
}