using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerPopup : MonoBehaviour
{
    public GameObject popupObject; // 需要浮现的UI元素
    public float fadeDuration = 1f; // 浮现时间

    private CanvasGroup canvasGroup;
    private bool isFading = false;

    void Start()
    {
        if (popupObject != null)
        {
            canvasGroup = popupObject.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = popupObject.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0; // 初始状态不可见
            popupObject.SetActive(false); // 确保初始状态下UI元素不可见
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name); 
        if (other.CompareTag("Hero") && !isFading)
        {
            StartCoroutine(FadeIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit called with: " + other.name); // 调试日志
        if (other.CompareTag("Hero") && !isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("FadeIn started");
        isFading = true;
        popupObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1;
        isFading = false;
        Debug.Log("FadeIn finished");
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("FadeOut started");
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        popupObject.SetActive(false);
        isFading = false;
        Debug.Log("FadeOut finished");
    }
}

