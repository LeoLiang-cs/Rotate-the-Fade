using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MushBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Collision coll;
    [Header("基本参数")]
    public float normalSpeed = 100f;
    public float chaseSpeed = 200f;
    public float currentSpeed;
    public Vector3 faceDir;

    [Header("计时器")]
    public float waitTime = 2f;
    public float waitTimeCounter;
    public bool isWaiting;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = normalSpeed;
        coll = GetComponent<Collision>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waitTimeCounter = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        faceDir = new Vector3(-transform.localScale.x, 0, 0);
        if (coll.onLeftWall && faceDir.x == -1 || coll.onRightWall && faceDir.x == 1)
        {
            isWaiting = true;
            anim.SetBool("Run", false);
        }
        TimeCounter();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(currentSpeed * faceDir.x * Time.deltaTime, rb.velocity.y);
        anim.SetBool("Run", true);
    }

    public void Flip(Vector2 attVec)
    {
        if(attVec.x - transform.position.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void TimeCounter()
    {
        if (isWaiting)
        {
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter < 0)
            {
                transform.localScale = new Vector3(faceDir.x, 1, 1);
                isWaiting = false;
                waitTimeCounter = waitTime;
            }
        }
    }
}
