using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Enemy : MonoBehaviour
{
    public GameObject MushchaseCupid;
    public Inputall MushroomJumpFllow;

    [Header("当前Cupid位置")]
    public Vector2 Cupidpostion;
    public bool LastisJump;

    public Rigidbody2D rb;
    public pythicscheck checktouch;
    public GameObject Cupid;



    [Header("基本参数")]
    public float currspeed;
    public float normalspeed;
    public float chasespeed;
    public Vector3 faceDire;


    [Header("计时器")]
    public float currwaittime;  //当前碰墙等待时间
    public float waitcontor;  //碰墙时间控制器
    public float chasewaitime;  //追击碰墙等待时间
    public float potalwaittime;  //训练碰撞等待时间
    public bool iswait = false;


    [Header("状态")]
    public Basestate currstate;  //当前状态
    public Basestate chasestate;  //追击状态
    public Basestate potalstate;  //巡逻状态
    public Basestate attckstate;  //攻击状态
    public Basestate deathstate;  //攻击状态
    public Basestate Forcestate;  //弹开状态


    [Header("检测")]
    public Vector2 centeroffist;  //中心点偏移
    public Vector2 checksize;  //发射体大小
    public float discent;   //探测距离
    public LayerMask player;    //检测图层
    public float chatime;   //追击时间
    public float chatimecontor; //追击时间控制器

    [Header("跳跃")]
    public float jumpFouse;



    private void Awake()
    {
        potalstate = new MushroomPatrolState();
        chasestate = new MushroomChaseState();
        rb = GetComponent<Rigidbody2D>();
        currspeed = normalspeed;
        checktouch = GetComponent<pythicscheck>();
        Cupid = GameObject.Find("Cupid");
       
        
        MushroomJumpFllow = new Inputall();
        MushroomJumpFllow.Game.CupidJump.started += ISMushroomJump;
        MushchaseCupid = GameObject.Find("Cupid");
        LastisJump = false;

    }

    private void OnEnable()         
    {
        currstate = potalstate;
        currstate.OnEnter(this);
    }

    private void Update()
    {
        faceDire = new Vector3(-transform.localScale.x, 0, 0);  //朝向
        currstate.Logicupdate();
    }

    private void FixedUpdate()
    {

        currstate.pythicupdate();
    }

    private void OnDisable()
    {
        currstate.OnExit();
    }

    public void move()
    {
        rb.velocity = new Vector2(faceDire.x * currspeed * Time.deltaTime, rb.velocity.y);
    }



    public void Timecontor()
    {
        if (iswait)
        {
            Debug.Log("indollwait");
            waitcontor -= Time.deltaTime;
            if (waitcontor <= 0)
            {
                iswait = false;
                waitcontor = currwaittime;
                transform.localScale = new Vector3(faceDire.x, 1, 1);

            }
        }
        if (!findplayer())
        {
            chatimecontor -= Time.deltaTime;
        }
        else
        {
            chatimecontor = chatime;
        }
    }

    private void ISMushroomJump(CallbackContext context)
    {
        Cupidpostion = new Vector2(MushchaseCupid.transform.position.x, MushchaseCupid.transform.position.y);
        LastisJump = true;

    }

    public void PostioninMushJump()
    {
        Vector2 MushPostion = new Vector2(transform.position.x, transform.position.y);
        if (LastisJump && MushPostion == Cupidpostion)
        {
            Jump();
            LastisJump = false;
        }
    }

    public void Swithstate(Mushroom_stateEnum state)
    {
        var newstate = state switch
        {
            Mushroom_stateEnum.potal => potalstate,
            Mushroom_stateEnum.chase => chasestate,
            Mushroom_stateEnum.attack => attckstate,
            Mushroom_stateEnum.death => deathstate,
            Mushroom_stateEnum.force => Forcestate,
            _ => null
        };
        currstate.OnExit();
        currstate = newstate;
        currstate.OnEnter(this);
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpFouse, ForceMode2D.Impulse);
    }

    public bool findplayer()  //检测是否看到player
    {
        Debug.Log("findplayer333");
        return Physics2D.BoxCast(transform.position + (Vector3)centeroffist, checksize, 0, faceDire, discent, player);
    }
    private void OnDrawGizmosSelected()  //画一个检查点
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + centeroffist + new Vector2(discent * -transform.localScale.x, 0), 0.2f);
    }

    //public void Swithstate(Mushroom_stateEnum state)  
    //{
    //    var newstate = state switch
    //    {
    //        Mushroom_stateEnum.potal => potalstate,
    //        Mushroom_stateEnum => chasestate,
    //        _ => null
    //    };
    //    currstate.OnExit();
    //    currstate = newstate;
    //    currstate.OnEnter(this);
    //}
}
