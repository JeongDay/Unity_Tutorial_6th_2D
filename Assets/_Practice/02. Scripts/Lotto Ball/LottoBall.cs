using TMPro;
using UnityEngine;

public class LottoBall : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    void Awake()
    {
        numberText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    // 외부에서 숫자를 적용하기 위한 함수
    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
    }
}