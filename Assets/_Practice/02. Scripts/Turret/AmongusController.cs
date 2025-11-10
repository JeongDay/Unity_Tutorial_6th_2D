using System;
using UnityEngine;

public class AmongusController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 dir;
    
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    public float jumpPower = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, 0, v).normalized;

        Jump();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    public void Move()
    {
        // rb.linearVelocity = dir * moveSpeed;

        Vector3 targetPosition = rb.position + dir * moveSpeed;
        
        rb.MovePosition(targetPosition);
    }
    
    public void Turn()
    {
        if (dir.x == 0 && dir.z == 0)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed);
        
        rb.MoveRotation(newRotation);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}