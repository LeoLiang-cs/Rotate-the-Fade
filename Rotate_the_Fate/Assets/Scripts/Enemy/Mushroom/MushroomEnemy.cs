using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Enemy : MonoBehaviour
{
    public GameObject MushchaseCupid;
    public Inputall MushroomJumpFllow;
    public PhysicsCheck pytcheck;

    [Header("当前Cupid位置")]
    public Vector2 Cupidpostion;
    public bool LastisJump;

    public Rigidbody2D rb;
    public PhysicsCheck checktouch;
    public GameObject Cupid;



    [Header("基本参数")]
    public float currspeed;
    public float normalspeed;
    public float chasespeed;
    public Vector3 faceDire;
    public float slowcl;//减慢因子


    [Header("计时器")]
    public float currwaittime;  //当前碰墙等待时间
    public float waitcontor;  //碰墙时间控制器
    public float chasewaitime;  //追击碰墙等待时间
    public float potalwaittime;  //巡逻碰撞等待时间
    public bool iswait = false;
    public Timer waitTimer;


    [Header("状态")]
    public BaseState currstate;  //当前状态
    public BaseState chasestate;  //追击状态
    public BaseState potalstate;  //巡逻状态
    public BaseState attckstate;  //攻击状态
    public BaseState deathstate;  //死亡状态
    public BaseState Forcestate;  //弹开状态


    [Header("检测")]
    public Vector2 centeroffist;  //中心点偏移
    public Vector2 checksize;  //发射体大小
    public float discent;   //探测距离
    public LayerMask player;    //检测图层
    public float chatime;   //追击时间
    public float chatimecontor; //追击时间控制器
    

    [Header("跳跃")]
    public float jumpFouse;

    [Header("碰撞检测")]
    public bool iscoll=false;
    [Header("健康系统")]
    public MushroomHealth health;



    private void Awake()
    {
        potalstate = new MushroomPatrolState();
        chasestate = new MushroomChaseState();
        deathstate= new MushroomdeathState();
        rb = GetComponent<Rigidbody2D>();
        currspeed = normalspeed;
        checktouch = GetComponent<PhysicsCheck>();
        pytcheck=GetComponent<PhysicsCheck>();
        Cupid = GameObject.Find("Cupid");
        waitTimer = gameObject.AddComponent<Timer>();
        health=GetComponent<MushroomHealth>();


       
        
        MushroomJumpFllow = new Inputall();
        MushroomJumpFllow.Game.CupidJump.started += ISMushroomJump;
        MushchaseCupid = GameObject.Find("Cupid");
        LastisJump = false;
        slowcl = 1f;
    }

    private void OnEnable()         
    {
        currstate = potalstate;
        currstate.OnEnter(this);
        waitTimer.Set_Timer(currwaittime, currwaittime + 1f);
        waitTimer.onComplete += Turnfacedir;
        TimeManager.Instance.AddTimer(waitTimer);

    }

    private void Update()
    {
        faceDire = new Vector3(-transform.localScale.x, 0, 0);  //朝向
        currstate.LogicUpdate();
    }

    private void FixedUpdate()
    {

        currstate.PhysicsUpdate();
    }

    private void OnDisable()
    {
        currstate.OnExit();
    }

    public void move()
    {
        rb.velocity = new Vector2(faceDire.x * currspeed * Time.deltaTime*slowcl, rb.velocity.y);
    }

    public void Timecontor()
    {
        if (iswait)
        {
            //Debug.Log("indollwait");
            waitcontor -= Time.deltaTime;
            if (waitcontor <= 0)
            {
                
                waitcontor = currwaittime;
                
                transform.localScale = new Vector3(faceDire.x, 1, 1);
                //float timef = 1f;
                //timef-= Time.deltaTime; 
                iswait = false;

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

    public void Turnfacedir()
    {
        transform.localScale = new Vector3(faceDire.x, 1, 1);
        //float timef = 1f;
        //timef-= Time.deltaTime; 
        iswait = false;
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            iscoll=true;
        }
    }

    public bool Lfindplayer()  //检测是否看到player
    {
        //Debug.Log("findplayer333");

        return Physics2D.BoxCast(transform.position + (Vector3)centeroffist, checksize, 0, faceDire, discent, player);
    }
    public bool findplayer()
    {
        if(Lfindplayer()||iscoll)
        {
            iscoll = false;
            return true;
        }
        else
        {
            return false;
        }
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
