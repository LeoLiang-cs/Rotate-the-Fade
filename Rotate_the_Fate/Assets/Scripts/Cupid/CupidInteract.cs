using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidInteract : MonoBehaviour
{
    Collider2D thing;
    public bool canGet = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetVase();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FrozenVase"))
        {
            canGet = true;
            thing = other;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("FrozenVase"))
        {
            canGet = false;
            thing = null;
        }

    }

    void GetVase()
    {

        if (canGet && Input.GetKeyDown(KeyCode.U))
        {
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Frozen);
        }
    }
}
