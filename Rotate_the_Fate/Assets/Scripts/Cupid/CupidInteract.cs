using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidInteract : MonoBehaviour
{
    Collider2D thing;
    public bool canGet = false;
    private AbilityDisplay ability_icon;
    private void Awake() {
        ability_icon = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
    }
    // Start is called before the first frame update
    void Start()
    {

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
        if(other.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            canGet = false;
            thing = null;
        }

    }

    void GetFrozen()
    {

        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "Vase")

        {
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Frozen);
            ability_icon.Add_Ability("frost");
        }
    }

    void GetFlame()
    {
        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "Brazier")
        {
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Flame);
        }
    }
}
