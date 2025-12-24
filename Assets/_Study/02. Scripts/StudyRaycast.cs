using System;
using UnityEngine;

public class StudyRaycast : MonoBehaviour
{
    public LayerMask layerMask;
    
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, transform.forward, out hitInfo, transform.rotation, 10f))
        {
            
        }
    }
}