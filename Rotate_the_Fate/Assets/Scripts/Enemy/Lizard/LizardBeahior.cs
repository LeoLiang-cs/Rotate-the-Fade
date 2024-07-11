using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class Liz : MonoBehaviour
{
    public GameObject LizardchaseCupid;
    //public Inputall MushroomJumpFllow;

    [Header("重力改变")]
    public Rigidbody2D rb;
    public GameObject Thegroud;

    [Header("当前Cupid位置")]
    public Vector2 Cupidpostion;
    public bool LastisJump;
    public LizardPcythicheck checktouch;
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
    public LizardBaseState currstate;  //当前状态
    public LizardBaseState chasestate;  //追击状态
    public LizardBaseState potalstate;  //巡逻状态
    public LizardBaseState attckstate;  //攻击状态
    public LizardBaseState deathstate;  //攻击状态
    public LizardBaseState Forcestate;  //弹开状态


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
        potalstate = new Lizardpatorl();
        chasestate = new Lizardchase();
        rb = GetComponent<Rigidbody2D>();
        currspeed = normalspeed;
        checktouch = GetComponent<LizardPcythicheck>();
        Cupid = GameObject.Find("Cupid");


        //MushroomJumpFllow = new Inputall();
        //MushroomJumpFllow.Game.CupidJump.started += ISMushroomJump;
        LizardchaseCupid = GameObject.Find("Cupid");
        LastisJump = false;

    }

    private void OnEnable()
    {
        currstate = potalstate;
        currstate.OnEnter(this);
    }

    private void Update()
    {
        //keepOnGroud();
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
        rb.velocity = new Vector2(-transform.localScale.x * currspeed * Time.deltaTime, rb.velocity.y);
    }

    public void keepOnGroud()
    {

        

        // 获取 Tilemap 的法向量
        Vector2 gravityDirection = -transform.up; // 假设法线为 Transform 的 up 方向

        // 计算新的重力向量（方向和大小）
        Vector2 newGravity = gravityDirection * Physics2D.gravity.magnitude * rb.gravityScale;

        // 应用新的重力向量
        Vector2 gravityEffect = newGravity * Time.fixedDeltaTime;
        rb.velocity -= Physics2D.gravity * rb.gravityScale * Time.fixedDeltaTime;

        // 应用新的重力向量影响速度
        rb.velocity += gravityEffect;
        //Gizmos.DrawWireSphere((Vector2)Thegroud.transform.position +(Vector2)Thegroud.transform.up, 0.2f);
        //if (Thegroud!= null)
        //{
        //    // 获取 Tilemap 的 Transform
        //    Transform tilemapTransformx = Thegroud.transform;

        //    // 将物体的坐标系设置为与平面一致
        //    transform.up = -tilemapTransformx.up; // 设置物体的 y 轴朝向为平面的法线方向
        //    transform.forward = tilemapTransformx.forward; // 设置物体的 z 轴朝向为平面的前向方向

        //}
        //    transform.rotation = tilemapTransform.rotation;
        //    Vector3 newScale = new Vector3(
        //            tilemapTransform.lossyScale.x, // 使用平面的x轴缩放
        //            tilemapTransform.lossyScale.y, // 使用平面的y轴缩放
        //            transform.localScale.z // 保持物体的z轴缩放不变
        //        );
        //    transform.localScale = newScale;
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
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);

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
        Cupidpostion = new Vector2(LizardchaseCupid.transform.position.x, LizardchaseCupid.transform.position.y);
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

    public void Swithstate(LizardStateEnum state)
    {
        var newstate = state switch
        {
            LizardStateEnum.potal => potalstate,
            LizardStateEnum.chase => chasestate,
            LizardStateEnum.attack => attckstate,
            LizardStateEnum.death => deathstate,
            LizardStateEnum.force => Forcestate,
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
        return Physics2D.BoxCast(transform.localPosition + (Vector3)centeroffist, checksize, 0, faceDire, discent, player);
    }
    private void OnDrawGizmosSelected()  //画一个检查点
    {
        Gizmos.DrawWireSphere((Vector2)transform.localPosition + centeroffist + new Vector2(discent * -transform.localScale.x, 0), 0.2f);
    }
}
