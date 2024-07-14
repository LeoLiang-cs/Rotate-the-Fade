using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidInteract : MonoBehaviour
{
    Collider2D thing;
    public bool canGet = false;
    private AbilityDisplay abilityDisplay;
    private void Awake() {
        abilityDisplay = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
    }
    private GameObject effect;

    private GameObject mushPlusSample;
    // Start is called before the first frame update
    void Start()
    {
        effect = Resources.Load<GameObject>("Prefabs/GetMagicEffect") as GameObject;
        mushPlusSample = Resources.Load<GameObject>("Prefabs/MushPlus") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetFrozen();
        GetFlame();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            canGet = true;
            thing = other;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            canGet = false;
            thing = null;
        }

    }

    void GetFrozen()
    {

        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "FrozenVase")

        {
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Frozen);
            abilityDisplay.Add_Ability("frost");

            MushSpawner();
        }
    }

    void GetFlame()
    {
        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "Brazier")
        {
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Flame);
        }
    }

    void MushSpawner()
    {
        GameObject mushPlus1 = GameObject.Instantiate(mushPlusSample) as GameObject;
        GameObject mushPlus2 = GameObject.Instantiate(mushPlusSample) as GameObject;
        mushPlus1.transform.position = transform.position + Vector3.right * 15f;
        mushPlus2.transform.position = transform.position + Vector3.left * 10f;

        mushPlus1.transform.Rotate(0f, 180f, 0f);
    }
}
