using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidInteract : MonoBehaviour
{
    Collider2D thing;
    public bool canGet = false;
    private AbilityDisplay abilityDisplay;
    private void Awake()
    {
        abilityDisplay = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
    }
    private GameObject effect;

    private GameObject mushPlusSample;
    public unlock unlockScript;
    // public GameObject FlameLeftWall;
    // public GameObject FlameRightWall;
    // Start is called before the first frame update
    void Start()
    {
        effect = Resources.Load<GameObject>("Prefabs/GetMagicEffect") as GameObject;
        mushPlusSample = Resources.Load<GameObject>("Prefabs/NewMushroom") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetFrozen();
        GetFlame();
        GetLightning();
        GetTimeFreeze();
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
            FindObjectOfType<AudioManager>().Play("getMagic");
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            thing.gameObject.GetComponent<GetMagic>().DestroyVase();
            //Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Frozen);
            abilityDisplay.Add_Ability("frost");
            unlockScript.UnlockCam();

            MushSpawner();
        }
    }

    void GetFlame()
    {
        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "Brazier")
        {
            FindObjectOfType<AudioManager>().Play("getMagic");
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.Flame);
            abilityDisplay.Add_Ability("flame");
            // CameraManager.Instance.SwitchToCamera((int)CameraIndex.PlayerFollow);
            // Destroy(FlameLeftWall);
            // Destroy(FlameRightWall);
            // WorldRotation script = GameObject.Find("World").GetComponent<WorldRotation>();
            // script.SetMagnified(false);
        }
    }

    void GetLightning()
    {
        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "FlashBottle")
        {
            FindObjectOfType<AudioManager>().Play("getMagic");
            Debug.Log("get lightning");
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            Destroy(thing.gameObject);
            GetComponent<Attack>().currentMagic.Add(MagicType.LightingChain);
            abilityDisplay.Add_Ability("lightening");
        }
    }

    void GetTimeFreeze()
    {
        if (canGet && Input.GetKeyDown(KeyCode.U) && thing.gameObject.tag == "sandClock")
        {
            Debug.Log("get Time Magic");
            GameObject getEffect = GameObject.Instantiate(effect) as GameObject;
            effect.transform.position = thing.transform.position;
            Destroy(thing.gameObject);
            GetComponent<Attack>().Add_Magic(MagicType.Time);
            abilityDisplay.Add_Ability("time");
        }
    }

    void MushSpawner()
    {
        GameObject mushPlus1 = GameObject.Instantiate(mushPlusSample) as GameObject;
        GameObject mushPlus2 = GameObject.Instantiate(mushPlusSample) as GameObject;
        GameObject mushPlus3 = GameObject.Instantiate(mushPlusSample) as GameObject;
        mushPlus1.transform.position = transform.position + Vector3.left * 15f;
        mushPlus2.transform.position = transform.position + Vector3.left * 13f;
        mushPlus3.transform.position = transform.position + Vector3.left * 8f;
        

    }
}
