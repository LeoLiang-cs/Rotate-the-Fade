using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenMagic : MonoBehaviour
{
    private static MagicSystem sMagicSystem = null;
    public static void InitializedMagicSystem(MagicSystem m) { sMagicSystem = m; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void DestroyThisMagic()
    {
        Destroy(transform.gameObject);  // kills self
        Attack.isAttacking = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("FrozenSpawner trigger");
        if (other.gameObject.CompareTag("Mushroom"))
        {
            other.GetComponent<MushroomHealth>().TakeFrozenDamage(transform.position);
        }else if(other.gameObject.CompareTag("Bush"))
        {
            other.GetComponent<BushHealth>().TakeFrozenDamage(transform.position);
        }else if(other.gameObject.CompareTag("Twinsnap"))
        {
            other.GetComponent<TwinHealth>().TakeFrozenDamage(transform.position);
        }else if(other.gameObject.CompareTag("SlimeDemon"))
        {
            Debug.Log("FrozenSlimeDemon");
            other.GetComponent<SDHealth>().TakeFrozenDamage(transform.position);
        }
    }
}
