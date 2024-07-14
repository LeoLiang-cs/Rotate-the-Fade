using UnityEngine;
using System.Collections;

public class PopupObject : MonoBehaviour
{
    public GameObject popupObject; // 需要浮现的UI元素
    public float fadeDuration = 1f; // 浮现时间

    private SpriteRenderer spriteRenderer;
    private bool isFading = false;

    void Start()
    {
        if (popupObject != null)
        {
            spriteRenderer = popupObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = popupObject.AddComponent<SpriteRenderer>();
            }
            Color color = spriteRenderer.color;
            color.a = 0; // 初始状态不可见
            spriteRenderer.color = color;
            popupObject.SetActive(false); // 确保初始状态下UI元素不可见
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("OnTriggerEnter called with: " + other.name);
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("OnTriggerExit called with: " + other.name); // 调试日志
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        popupObject.SetActive(true);
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 1;
        spriteRenderer.color = color;
        isFading = false;
    
    }

    private IEnumerator FadeOut()
    {
     
        isFading = true;
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0;
        spriteRenderer.color = color;
        popupObject.SetActive(false);
        isFading = false;
       // Debug.Log("FadeOut finished");
    }
}
