using System.Collections.Generic;
using UnityEngine;

public class StudyLoop : MonoBehaviour
{
    public string[] personNames;
    
    public string findName;
    
    void Start()
    {
        FindPerson();
    }

    private void FindPerson()
    {
        foreach (var personName in personNames)
        {
            if (personName == findName)
            {
                Debug.Log(findName + "을 찾았습니다.");
            }
        }
    }
}