using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset = new Vector3(0, 0.7f, 0);

    public float rotSpeed = 75f;

    private float mx, my;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        transform.position = target.position + offset;
    }

    private void Turn()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -87f, 87f);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}