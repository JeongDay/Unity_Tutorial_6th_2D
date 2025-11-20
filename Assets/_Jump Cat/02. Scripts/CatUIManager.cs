using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatUIManager : MonoBehaviour
{
    public CatSoundManager sound;
    
    public TMP_InputField inputUI;
    public TextMeshProUGUI catNameUI;
    public TextMeshProUGUI fruitCountUI;
    public TextMeshProUGUI timerUI;

    public Button startButton;

    public GameObject introUI;
    public GameObject playObj;

    public static int fruitCount; // 정적변수

    void Start()
    {
        startButton.onClick.AddListener(StartEvent); // 스타트 버튼에 StartEvent 함수 등록
    }
    
    private void StartEvent() // Intro -> Play
    {
        sound.BGMSound(1); // Play 배경음악
        catNameUI.text = inputUI.text; // 입력한 텍스트를 고양이 이름에 적용
        playObj.SetActive(true);
        introUI.SetActive(false);
    }
}