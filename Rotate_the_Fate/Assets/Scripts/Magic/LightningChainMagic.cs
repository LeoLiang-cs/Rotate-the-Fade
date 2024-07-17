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

    public void TriggerLightningChain(Vector3 p)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(p, radius, enemyLayer);
        Collider2D[] hitStab = Physics2D.OverlapCircleAll(p, radius, stabLayer);
        Debug.Log("enemy num: "+hitEnemies.Length);
        foreach (Collider2D enemy in hitEnemies)
        {
            DrawLightning(p, enemy.transform.position);
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

        foreach (Collider2D stab in hitStab)
        {
            DrawLightning(p, stab.transform.position);

        }
        Attack.isAttacking = false;

        Destroy(transform.gameObject, 0.1f);
    }

    void DrawLightning(Vector2 start, Vector2 end)
    {
        // ÉÏÒÆ y Öá 0.5f
        start.y += 1f;
        end.y += 1f;

        // Debug.Log("DrawLightning: " + start + " " + end);
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

}
