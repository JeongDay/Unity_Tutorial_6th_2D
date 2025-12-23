using System;
using UnityEngine;

public class StudyRaycast : MonoBehaviour
{
    public LayerMask layerMask;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                Debug.Log($"선택한 오브젝트 : {hitInfo.collider.name}");
            }
        }
    }
}