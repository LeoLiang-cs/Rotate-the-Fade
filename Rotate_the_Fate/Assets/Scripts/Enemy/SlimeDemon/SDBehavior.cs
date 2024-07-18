using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDBehavior : MonoBehaviour
{
    private Animator anim;
    private Collision coll;
    private Rigidbody2D rb;
    private GameObject Cupid;
    private SDHealth sdHealth;
    private SDAttack sdAttack;
    private SDTimeStop timeStop;

    [Header("基本参数")]
    public float currentSpeed = 400f;
    public Vector3 faceDire;
    public float slowFactor;//减慢因子


    void Awake()
    {
        sdAttack = GetComponent<SDAttack>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collision>();
        sdHealth = GetComponent<SDHealth>();
        timeStop = GetComponent<SDTimeStop>();
        Cupid = GameObject.Find("Cupid");
        currentSpeed = 400f;
        slowFactor = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sdHealth.isHitting || sdHealth.isDead || sdHealth.isTransforming || sdAttack.isAttacking || timeStop.isStopped)
        {
            return;
        }


        faceDire = new Vector3(-transform.localScale.x, 0, 0).normalized;
        Flip();
        Move();
    }

    void Move()
    {
        if (coll.onGround)
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
