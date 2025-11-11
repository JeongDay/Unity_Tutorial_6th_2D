using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Vector3 startPos;

    public float moveSpeed = 1f;
    
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -10)
        {
            transform.position = startPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");

            Time.timeScale = 0f;
        }
    }
}