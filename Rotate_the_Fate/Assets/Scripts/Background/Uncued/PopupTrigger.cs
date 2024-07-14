using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerPopup : MonoBehaviour
{
    public GameObject popupObject; // ��Ҫ���ֵ�UIԪ��
    private float fadeDuration = 0.01f; // ����ʱ��

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
            canvasGroup.alpha = 0; // ��ʼ״̬���ɼ�
            popupObject.SetActive(false); // ȷ����ʼ״̬��UIԪ�ز��ɼ�
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
        //Debug.Log("OnTriggerExit called with: " + other.name); // ������־
        if (other.CompareTag("Player") && !isFading)
        {
            // StartCoroutine(FadeOut());
            if(canvasGroup != null){
                canvasGroup.alpha = 0;
            }
        }
    }

    private IEnumerator FadeIn()
    {
      
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
       
    }

    private IEnumerator FadeOut()
    {
      
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
       // Debug.Log("FadeOut finished");
    }
}

