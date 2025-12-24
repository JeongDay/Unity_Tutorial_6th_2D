using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Vector3 destinationPos;

    public float moveSpeed = 5f;
    private bool isMove = false;

    void Update()
    {
        if (!isMove)
            return;
        
        var moveDir = (destinationPos - transform.position).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
        var remainDistance = Vector3.Distance(transform.position, destinationPos);
        if (remainDistance <= 0.25f)
        {
            isMove = false;
            Debug.Log("목적지 도착");
        }
    }

    public void SetMovement(Vector3 destinationPos)
    {
        isMove = true;
        destinationPos.y = transform.position.y;
        this.destinationPos = destinationPos;
    }
}