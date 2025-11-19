using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void ButtonEvent() 
    {
        Debug.Log("버튼 클릭");
    }

    public void OnLog(string msg)
    {
        Debug.Log(msg);
    }
}