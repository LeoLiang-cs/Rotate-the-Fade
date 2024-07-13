using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collision coll;
    public Animator anim;
     private GameObject Cupid;


    [Header("基本参数")]
    public float currentSpeed;
    public float normalSpeed = 50f;
    public float chaseSpeed;
    public Vector3 faceDire;
    public float slowFactor;//减慢因子

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Cupid = GameObject.Find("Cupid");
        coll = GetComponent<Collision>();   
        currentSpeed = normalSpeed;
        slowFactor = 1f;
    }


    void Start()
    {

    }

    void Update()
    {
        faceDire = new Vector3(-transform.localScale.x, 0, 0).normalized;
        Flip();
        Move();
    }

    void Move()
    {   
        if (coll.onGround)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        rb.velocity = new Vector2(faceDire.x * currentSpeed * Time.deltaTime * slowFactor, rb.velocity.y);
        
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
