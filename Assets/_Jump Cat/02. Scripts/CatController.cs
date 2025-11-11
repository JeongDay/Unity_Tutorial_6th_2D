using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;
    
    public float jumpPower = 10f;
    public float limitVelocity = 5f;
    public int jumpCount;
    
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            if (catRb.linearVelocityY > limitVelocity)
            {
                catRb.linearVelocityY = limitVelocity;
            }
        }
    }
}