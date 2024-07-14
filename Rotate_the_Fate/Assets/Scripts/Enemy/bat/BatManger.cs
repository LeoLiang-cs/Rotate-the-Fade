using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BatManger : MonoBehaviour
{
    Animator anim;
    [Header("基本参数")]
    public float currspeed;
    public float chasespeed;
    public float attackspeed;
    public float backspeed;
    public float staticspeed;

    [Header("状态")]
    public BatBaseState currstate;
    public BatBaseState chasestate;
    public BatBaseState attackstate;
    public BatBaseState backstate;
    public BatBaseState staicstate;

    [Header("前进方向")]
    public Vector2 currfaceDir;
    public GameObject CuipdPlay;
    public Vector2 priLocation;

    [Header("检测")]
    public float radis;
    public float chasewaitTime;
    public float chasetimeCon;
    public float attackradis;

    [Header("攻击")]
    public Vector2 lastPostaton;
    public   bool isattack;
    public float AttDistant;


    private void Awake()
    {
        chasestate = new BatChaseState();
        attackstate= new BatAttackState();
        backstate = new BatBackState();
        priLocation = transform.position;
        staicstate = new BatStaicState();
        CuipdPlay = GameObject.Find("Cupid");
        isattack = false;
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        currstate = staicstate;
        currstate.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
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

    public bool BackToPor()
    {
        return (Vector2)transform.position == priLocation;
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, currfaceDir, currspeed * Time.deltaTime);
    }

    public bool findplayer()
    {
        if(CuipdPlay != null)
        {
            float distance=(transform.position - CuipdPlay.transform.position).sqrMagnitude;
            if(distance < radis)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool findAttack()
    {
        if(CuipdPlay != null)
        {
            float distance = (transform.position - CuipdPlay.transform.position).sqrMagnitude;
            if(distance<attackradis+AttDistant)
            {
                if (!isattack)
                {
                    lastPostaton = transform.position;
                    Debug.Log("找到敌人，开始攻击" + lastPostaton);
                    isattack = true;
                    anim.SetBool("Fly", true);
                    Debug.Log("攻击状态1" + isattack);
                }
            }
            if (distance < attackradis)
            {
                

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        { return false; }
    }
    

    public void TimeConToner()
    {
        if(!findplayer())
        {
            chasetimeCon-=Time.deltaTime;
        }
        else
        {
            chasetimeCon = chasewaitTime;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        Debug.Log("inbanck");
    //        transform.position = lastPostaton;
    //        isattack = false;
    //    }
    //}

    



    public void Swithstate(BatStateEnum state)
    {
        var newstate = state switch
        {
            BatStateEnum.staic=>staicstate,
            BatStateEnum.chase=>chasestate,
            BatStateEnum.attack=>attackstate,
            BatStateEnum.back=>backstate,
            _ => null
        };
        currstate.OnExit();
        currstate = newstate;
        currstate.OnEnter(this);
    }


    public void WaitForTwo()
    {
        Invoke("TurnBack", 0.1f);
    }
    
    public void TurnBack()
    {
        Debug.Log("进入攻击位置");
        transform.position = lastPostaton;
        Invoke("CoolDown", 1f);

    }
    public void CoolDown()
    {

        isattack = false;
        Debug.Log("isattack" + isattack);
    }
}
