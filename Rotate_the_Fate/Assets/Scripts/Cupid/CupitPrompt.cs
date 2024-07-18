using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CupitPrompt : MonoBehaviour
{
    private Attack attack;
    private CupidHealth cupidHealth;

    public GameObject deathUIPrefab; // ËÀÍöUIÔ¤ÖÆ¼þ
    private GameObject deathUIInstance;
    private CanvasGroup deathUICanvasGroup;

    public TextMeshProUGUI noEnergyUI;
    private bool isFading;
    public float fadeDuration = 1f;

    void Awake()
    {
        attack = GetComponent<Attack>();
        cupidHealth = GetComponent<CupidHealth>();
    }

    void Start()
    {
        isFading = false;
    }

    void Update()
    {
        DeathPrompt();
        NoEnergyPrompt();
    }

    void DeathPrompt()
    {
        if (cupidHealth.currentHealth <= 0)
        {
            if (deathUIInstance == null)
            {
                deathUIInstance = Instantiate(deathUIPrefab, transform);
                deathUICanvasGroup = deathUIInstance.GetComponent<CanvasGroup>();
                if (deathUICanvasGroup == null)
                {
                    deathUICanvasGroup = deathUIInstance.AddComponent<CanvasGroup>();
                }
                StartCoroutine(FadeIn(deathUIInstance, deathUICanvasGroup));
            }
        }
        else if (deathUIInstance != null)
        {
            Destroy(deathUIInstance);
        }
    }

    void NoEnergyPrompt()
    {
        if (attack.magicEnergy <= attack.currentMagicCost && Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(FadeIn(noEnergyUI));
        }
        if (attack.magicEnergy > attack.currentMagicCost)
        {
            TurnOff(noEnergyUI);
        }
    }

    private IEnumerator FadeIn(GameObject popupObject, CanvasGroup canvasGroup)
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

    private IEnumerator FadeIn(TextMeshProUGUI ui)
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            ui.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ui.alpha = 1;
        isFading = false;
    }

    private void TurnOff(TextMeshProUGUI ui)
    {
        Color color = ui.color;
        color.a = 0f;
        ui.color = color;
    }
}
