using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color initColor; // 처음 컬러

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        
        initColor = renderer.color;
    }

    public void HitColor()
    {
        renderer.color = Color.red;

        Invoke("ReturnColor", 0.2f);

        Debug.Log("색 변경");
    }

    public void ReturnColor()
    {
        renderer.color = initColor;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.name == "Ball")
    //     {
    //         HitColor();
    //     }
    // }
}