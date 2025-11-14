using System.Collections.Generic;
using UnityEngine;

public class StudyRandom : MonoBehaviour
{
    public List<int> numbers = new List<int>();
    
    public List<int> lottoNumbers = new List<int>();
    
    public int count = 1000;
    
    void Start()
    {
        CreateNumber();
        ShuffleNumber();
        PickNumber();
    }

    // 로또 번호 만들기
    private void CreateNumber()
    {
        for (int i = 1; i < 46; i++)
        {
            numbers.Add(i);
        }
    }
    
    // 로또 번호 섞기
    private void ShuffleNumber()
    {
        for (int i = 0; i < count; i++)
        {
            int ran1 = Random.Range(0, numbers.Count);
            int ran2 = Random.Range(0, numbers.Count);
        
            // Swap 기능 : 데이터 자리 바꾸기
            int temp = numbers[ran1];
            numbers[ran1] = numbers[ran2];
            numbers[ran2] = temp;
        }
    }

    // 로또 번호 선택하기
    private void PickNumber()
    {
        for (int i = 0; i < 6; i++) // 6개 숫자 뽑기
        {
            lottoNumbers.Add(numbers[i]);
        }
        
        lottoNumbers.Sort(); // 오름차순 정렬

        string msg = "";
        foreach (var num in lottoNumbers)
        {
            msg += num + ", ";
        }

        Debug.Log("로또 번호 : " + msg);

        // Debug.Log($"이번 주 로또 번호 : {lottoNumbers[0]}, {lottoNumbers[1]}, {lottoNumbers[2]}, {lottoNumbers[3]}, {lottoNumbers[4]}, {lottoNumbers[5]}");
    }
}