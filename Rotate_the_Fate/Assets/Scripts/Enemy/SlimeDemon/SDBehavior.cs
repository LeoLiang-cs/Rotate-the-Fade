using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDBehavior : MonoBehaviour
{
    

    private Animator anim;
    private Collision coll;
    private Rigidbody2D rb;
    private GameObject Cupid;

    [Header("基本参数")]
    public float currentSpeed = 200f;
    public Vector3 faceDire;
    public float slowFactor;//减慢因子


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collision>();
        Cupid = GameObject.Find("Cupid");
        currentSpeed = 200f;
        slowFactor = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<SDHealth>().isHitting || GetComponent<SDHealth>().isDead)
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
