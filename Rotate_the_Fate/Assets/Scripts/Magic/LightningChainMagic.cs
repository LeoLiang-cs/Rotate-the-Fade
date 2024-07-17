using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChainMagic : MonoBehaviour
{
    public float radius = 5.0f;  // æ£€æµ‹åŠå¾?
    public LayerMask enemyLayer;  // æ•Œäººçš„å›¾å±?
    public LayerMask stabLayer;  // æ•Œäººçš„å›¾å±?
    public int damage = 10;  // é€ æˆçš„ä¼¤å®?
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerLightningChain(Collider2D enemy, Vector2 p)
    {
        if (enemy.gameObject.CompareTag("Mushroom"))
        {
            enemy.GetComponent<NewMushroomHealth>().TakeLighteningChainDamage(p);
        }
        else if (enemy.gameObject.CompareTag("Bush"))
        {
            enemy.GetComponent<BushHealth>().TakeLighteningChainDamage();
        }
        else if (enemy.gameObject.CompareTag("Bat"))
        {
            enemy.GetComponent<BatHealth>().TakeLighteningChainDamage(p);
        }
        else if (enemy.gameObject.CompareTag("Twinsnap"))
        {
            enemy.GetComponent<TwinHealth>().TakeLighteningChainDamage(p);
        }
        else if (enemy.gameObject.CompareTag("SlimeDemon"))
        {
            enemy.GetComponentInParent<SDHealth>().TakeLighteningChainDamage(p);
        }

    }

    public void DrawLightning(Vector2 start, Vector2 end)
    {
        // ÉÏÒÆ y Öá 0.5f
        start.y += 1f;
        end.y += 1f;

        // Debug.Log("DrawLightning: " + start + " " + end);
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public void DestroyThisMagic()
    {
        Destroy(transform.gameObject, 0.2f);  // kills self
        Attack.isAttacking = false;
    }

}
