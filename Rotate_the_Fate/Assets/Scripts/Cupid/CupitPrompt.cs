using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupitPrompt : MonoBehaviour
{
    private Attack attack;
    private CupidHealth cupidHealth;
    public GameObject deathUIPanel;
    void Awake()
    {
        attack = GetComponent<Attack>();
        cupidHealth = GetComponent<CupidHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void NoEnergyPrompt()
    {
        if (attack.magicEnergy <= attack.currentMagicCost)
        {

        }
    }
}
