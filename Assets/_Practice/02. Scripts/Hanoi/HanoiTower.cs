using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    [SerializeField] private GameObject[] ringPrefabs;

    [SerializeField] private BoardStick[] sticks;

    public List<GameObject> stackPreView1 = new List<GameObject>();
    public List<GameObject> stackPreView2 = new List<GameObject>();
    public List<GameObject> stackPreView3 = new List<GameObject>();


    public static GameObject selectedRing;
    public static bool isSelected;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefabs[i]);

            ring.transform.position = new Vector3(-7f, 5f, 0); // Left Stick 위에 생성

            sticks[0].stack.Push(ring); // Left Stick의 스택 자료구조에 데이터 추가

            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        stackPreView1 = sticks[0].stack.ToList();
        stackPreView2 = sticks[1].stack.ToList();
        stackPreView3 = sticks[2].stack.ToList();
    }
}