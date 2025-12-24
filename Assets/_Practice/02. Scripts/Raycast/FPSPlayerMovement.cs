using System;
using UnityEngine;

public class FPSPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 moveVelocity;

    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public float rotSpeed = 75f;
    private float mx;

    public float groundDistance = 1.1f;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turn();
        Jump();
        CheckGround();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var moveDir = new Vector3(h, 0, v).normalized; // 월드 좌표 기준

        var targetDir = Camera.main.transform.TransformDirection(moveDir); // 메인 카메라의 로컬 좌표 기준
        targetDir.y = 0;

        targetDir.Normalize();

        moveVelocity = targetDir * moveSpeed;
    }

    private void Turn()
    {
        float mouseX = Input.GetAxis("Mouse X");

        mx += mouseX * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void CheckGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, groundDistance);

        Debug.DrawRay(transform.position, Vector3.down * groundDistance, isGround ? Color.green : Color.red);
    }
}