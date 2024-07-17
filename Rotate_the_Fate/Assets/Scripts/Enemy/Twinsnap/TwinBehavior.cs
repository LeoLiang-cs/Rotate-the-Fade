using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision coll;
    private TwinAttack twinAttack;
    private Animator anim;
    public GameObject Cupid;
    private TwinAttackDetect attackDetect;
    private TwinHealth twinHealth;


    [Header("基本参数")]
    public float currentSpeed;
    public float normalSpeed = 200f;
    public float chaseSpeed;
    public Vector3 faceDire;
    public float slowFactor;//减慢因子

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Cupid = GameObject.Find("Cupid");
        coll = GetComponent<Collision>();
        attackDetect = GetComponent<TwinAttackDetect>();
        twinAttack = GetComponent<TwinAttack>();
        twinHealth = GetComponent<TwinHealth>();
        currentSpeed = normalSpeed;
        slowFactor = 1f;
    }


    void Start()
    {

    }

    void Update()
    {
     if(twinHealth.isHitting || twinHealth.isDead)
        {
            return;
        }
        faceDire = new Vector3(-transform.localScale.x, 0, 0).normalized;
        Flip();
        Move();
    }

    void Move()
    {
        if (coll.onGround && !twinAttack.isAttacking && !twinAttack.isShotting)
        {
            anim.SetBool("Walk", true);
            rb.velocity = new Vector2(faceDire.x * currentSpeed * Time.deltaTime * slowFactor, rb.velocity.y);
        }
        

    }

    void Flip()
    {
        if (Cupid.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
