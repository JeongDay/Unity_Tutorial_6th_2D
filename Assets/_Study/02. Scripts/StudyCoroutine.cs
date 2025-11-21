using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StudyCoroutine : MonoBehaviour
{
    public Image fadeUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeRoutine());
        }
    }

    IEnumerator FadeRoutine()
    {
        Color newColor = fadeUI.color;

        while (true)
        {
            yield return null;

            newColor.a = Mathf.Lerp(newColor.a, 1f, Time.deltaTime);

            fadeUI.color = newColor;
        }
    }
}