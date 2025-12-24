using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private Collider coll;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var closestPos = other.ClosestPoint(transform.position);
        transform.position = closestPos;

        transform.SetParent(other.transform);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        coll.enabled = false;
    }
}