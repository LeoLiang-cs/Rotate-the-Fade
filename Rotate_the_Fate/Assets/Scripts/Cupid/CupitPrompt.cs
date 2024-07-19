using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CupitPrompt : MonoBehaviour
{
    private Attack attack;
    private CupidHealth cupidHealth;

    public TextMeshProUGUI deathUI;
    public TextMeshProUGUI noEnergyUI;
    private bool isFading;
    public float fadeDuration = 1f;
    void Awake()
    {
        attack = GetComponent<Attack>();
        cupidHealth = GetComponent<CupidHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        DeathPrompt();
        NoEnergyPrompt();
    }

    void DeathPrompt()
    {
        if (cupidHealth.currentHealth <= 0)
        {
            //    TurnOn(deathUI);
           StartCoroutine(FadeIn(deathUI));
        }
        if (cupidHealth.currentHealth > 0)
        {
            TurnOff(deathUI);
        }
    }

    void NoEnergyPrompt()
    {
        if (attack.magicEnergy <= attack.currentMagicCost && Input.GetKeyDown(KeyCode.J))
        {
            // TurnOn(noEnergyUI);
            StartCoroutine(FadeIn(noEnergyUI));
            //FadeIn(noEnergyUI);
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

    // private void TurnOn(TextMeshProUGUI ui)
    // {
    //     Color color = ui.color;
    //     color.a = 1f;
    //     ui.color = color;
    // }
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
