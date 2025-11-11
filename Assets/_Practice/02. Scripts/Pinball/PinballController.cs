using UnityEngine;

public class PinballController : MonoBehaviour
{
    public Rigidbody2D leftHandleRb;
    public Rigidbody2D rightHandleRb;

    public float pushPower = 10f;
    public float releasePower = 30f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftHandleRb.AddTorque(pushPower, ForceMode2D.Impulse);
        }
        else
        {
            leftHandleRb.AddTorque(-releasePower);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightHandleRb.AddTorque(-pushPower, ForceMode2D.Impulse);
        }
        else
        {
            rightHandleRb.AddTorque(releasePower);
        }
    }
}