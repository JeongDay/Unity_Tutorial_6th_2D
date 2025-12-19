using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    [SerializeField] private GameObject[] ringPrefabs;
    
    [SerializeField] private BoardStick[] sticks;

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
}