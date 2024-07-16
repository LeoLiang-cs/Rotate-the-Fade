using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class BatManger : MonoBehaviour
{
    Animator anim;
    [Header("��������")]
    public float currspeed;
    public float chasespeed;
    public float attackspeed;
    public float backspeed;
    public float staticspeed;

    [Header("״̬")]
    public BatBaseState currstate;
    public BatBaseState chasestate;
    public BatBaseState attackstate;
    public BatBaseState backstate;
    public BatBaseState staicstate;

    [Header("ǰ������")]
    public Vector2 currfaceDir;
    public GameObject CuipdPlay;
    public Vector2 priLocation;

    [Header("���?")]
    public float radis;
    public float chasewaitTime;
    public float chasetimeCon;
    public float attackradis;

    [Header("����")]
    public Vector2 lastPostaton;
    public bool isattack;
    public float AttDistant;
    //public BatpythCheck pytCheck;


    private void Awake()
    {
        chasestate = new BatChaseState();
        attackstate = new BatAttackState();
        backstate = new BatBackState();
        priLocation = transform.position;
        staicstate = new BatStaicState();
        CuipdPlay = GameObject.Find("Cupid");
        isattack = false;
        chasetimeCon = chasewaitTime;
        anim = GetComponent<Animator>();
        chasetimeCon = chasewaitTime;
        //pytCheck=GetComponent<BatpythCheck>();
    }
    private void OnEnable()
    {
        currstate = staicstate;
        currstate.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        //pytCheck.check();
        
Flip();
        currstate.Logicupdate();
    }
    void FixedUpdate()
    {
        currstate.pythicupdate();
        
    }



    private void OnDisable()
    {
        currstate.OnExit();
    }

    public bool BackToPor()
    {
        return (Vector2)transform.localPosition == priLocation;
    }

    public void Move()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, currfaceDir, currspeed * Time.deltaTime);
        // transform.localScale=new Vector3(Mathf.Abs(currfaceDir.x)/currfaceDir.x,1,1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查其他物体是否在 'Player' 图层
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("检测到图层");
            Swithstate(BatStateEnum.back);
        }
    }

    public bool findplayer()
    {
        Debug.Log("����findplayer");
        if (CuipdPlay != null)
        {
            float distance = (transform.localPosition - CuipdPlay.transform.position).sqrMagnitude;
            if (distance < radis)
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
        if (CuipdPlay != null)
        {
            float distance = (transform.localPosition - CuipdPlay.transform.position).sqrMagnitude;
            if (distance < attackradis + AttDistant)
            {
                if (!isattack)
                {
                    lastPostaton = transform.localPosition;
                    Debug.Log("�ҵ����ˣ���ʼ����" + lastPostaton);
                    isattack = true;
                    anim.SetBool("Fly", true);
                    Debug.Log("����״̬1" + isattack);
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
        if (!findplayer())
        {
            chasetimeCon -= Time.deltaTime;
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
            BatStateEnum.staic => staicstate,
            BatStateEnum.chase => chasestate,
            BatStateEnum.attack => attackstate,
            BatStateEnum.back => backstate,
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

        transform.localPosition = lastPostaton;
        Invoke("CoolDown", 1f);

    }
    public void CoolDown()
    {

        isattack = false;
        Debug.Log("isattack" + isattack);
    }

    void Flip()
    {
        Debug.Log("bat position" + transform.position + "  CuipdPlay position" + CuipdPlay.transform.position);
        if (CuipdPlay.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
