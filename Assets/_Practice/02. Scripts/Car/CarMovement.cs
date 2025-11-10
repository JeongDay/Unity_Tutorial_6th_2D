using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D carRb;

    public float moveSpeed = 3f;
    private float h;

    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        carRb.linearVelocityX = h * moveSpeed;
    }

    // void OnCollisionEnter2D(Collision2D other) // 충돌 하자마자 1번 실행하는 이벤트
    // {
    //     if (other.gameObject.CompareTag("Monster"))
    //     {
    //         Destroy(other.gameObject); // 몬스터 파괴
    //     }
    // }
    //
    // void OnCollisionStay2D(Collision2D other)
    // {
    //     
    // }
    //
    // void OnCollisionExit2D(Collision2D other)
    // {
    //     
    // }
}