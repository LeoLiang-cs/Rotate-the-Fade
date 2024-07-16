using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMagic : MonoBehaviour
{
    public int damage = 5;
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
        Attack.isAttacking = false;
        Destroy(transform.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            other.GetComponent<NewMushroomHealth>().TakeFlameDamage(transform.position);
        }
        else if (other.gameObject.CompareTag("Bush"))
        {
            other.GetComponent<BushHealth>().TakeFlameDamage(transform.position);
        }
        else if (other.gameObject.CompareTag("Twinsnap"))
        {
            other.GetComponent<TwinHealth>().TakeFlameDamage(transform.position);
        }
        else if (other.gameObject.CompareTag("Bat"))
        {
            other.GetComponent<BatHealth>().TakeFlameDamage(transform.position);
        }
    }
}
