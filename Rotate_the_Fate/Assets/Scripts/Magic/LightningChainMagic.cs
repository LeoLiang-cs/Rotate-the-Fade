using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChainMagic : MonoBehaviour
{
    public float radius = 5.0f;  // 检测半径
    public LayerMask enemyLayer;  // 敌人的图层
    public int damage = 10;  // 造成的伤害
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
                enemy.GetComponent<MushroomHealth>().TakeLighteningChainDamage();
            }else if(enemy.gameObject.CompareTag("Bush")) {
                enemy.GetComponent<BushHealth>().TakeLighteningChainDamage();
            }else if (enemy.gameObject.CompareTag("Bat"))
            {
                enemy.GetComponent<MushroomHealth>().TakeLighteningChainDamage();
            }
        }
        Attack.isAttacking = false;

        Destroy(transform.gameObject, 0.5f);
    }

    void DrawLightning(Vector2 start, Vector2 end)
    {
        
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        // 销毁闪电对象在0.5秒后
        //Destroy(transform.gameObject, 0.5f);
        //Attack.isAttacking = false;
    }
}
