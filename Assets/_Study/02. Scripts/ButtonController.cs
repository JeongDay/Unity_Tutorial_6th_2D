using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TMP_InputField inputUI;
    public TextMeshProUGUI textUI;

    public Button buttonUI;

    void Start()
    {
        buttonUI.onClick.AddListener(SetText); // 버튼에 함수를 등록하는 기능

        /*
        buttonUI.onClick.RemoveListener(SetText); // 버튼에 등록된 함수를 지우는 기능
        buttonUI.onClick.RemoveAllListeners(); // 버튼에 등록된 함수를 모두 지우는 기능
        */
    }
    
    public void SetText()
    {
        textUI.text += inputUI.text;

        // string msg = "안녕하세요." + "유니티입니다.";
    }
}