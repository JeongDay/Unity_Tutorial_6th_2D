using TMPro;
using UnityEngine;

public class LottoBall : MonoBehaviour
{
    private TextMeshProUGUI numberText;

    void Start()
    {
        numberText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // 외부에서 숫자를 적용하기 위한 함수
    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
    }
}