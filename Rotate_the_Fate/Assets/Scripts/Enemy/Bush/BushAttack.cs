using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushAttack : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask player;

    [Header("FindPlayer")]
    public float collisionRadius = 1f;
    public bool isAttacking = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        findplayer();
    }

    public void findplayer()  //检测是否看到player
    {
        if( Physics2D.OverlapCircle((Vector2)transform.position, collisionRadius, player) && !isAttacking)
        {
            isAttacking = true;
            FindObjectOfType<AudioManager>().Play("bushAttack");
            anim.SetTrigger("Attack");
            
        }

    }
    private void OnDrawGizmosSelected()  //画一个检查点
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position, collisionRadius);
    }

    private void idle2attack()
    {
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    private void attack2idle()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        isAttacking = false ;
    }


}
