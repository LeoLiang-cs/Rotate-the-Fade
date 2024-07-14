using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChainMagic : MonoBehaviour
{
    public float radius = 5.0f;  // æ£€æµ‹åŠå¾?
    public LayerMask enemyLayer;  // æ•Œäººçš„å›¾å±?
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
        foreach (Collider2D enemy in hitEnemies)
        {
            DrawLightning(p, enemy.transform.position);
            if (enemy.gameObject.CompareTag("Mushroom")) {
                enemy.GetComponent<MushroomHealth>().TakeLighteningChainDamage(p);
            }else if(enemy.gameObject.CompareTag("Bush")) {
                enemy.GetComponent<BushHealth>().TakeLighteningChainDamage();
            }else if (enemy.gameObject.CompareTag("Bat"))
            {
                enemy.GetComponent<MushroomHealth>().TakeLighteningChainDamage(p);
            }else if(enemy.gameObject.CompareTag("Twinsnap")) {
                enemy.GetComponent<TwinHealth>().TakeLighteningChainDamage(p);
            }
        }
        Attack.isAttacking = false;

        Destroy(transform.gameObject, 0.2f);
    }

void DrawLightning(Vector2 start, Vector2 end)
{
    // ÉÏÒÆ y Öá 0.5f
    start.y += 1f;
    end.y += 1f;

    Debug.Log("DrawLightning: " + start + " " + end);
    LineRenderer lr = GetComponent<LineRenderer>();
    lr.SetPosition(0, start);
    lr.SetPosition(1, end);
}

}
