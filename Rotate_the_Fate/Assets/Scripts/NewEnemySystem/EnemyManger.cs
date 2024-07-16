using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEditor.Rendering.InspectorCurveEditor;

public class EnemyManger : MonoBehaviour
{
    [Header("InformationOfCupid")]
    public Transform CupidTransform;
    public bool LastJump;
    public GameObject Cupidd;


    [Header("EnemyBaseInformation")]
    public Rigidbody2D rb;
    public PychicsCheck CheckOfTouch;


    [Header("MoveNum")]
    public float CurrSpeed;
    public float PatrolSpeed;
    public float ChaseSpeed;
    public Vector3 FaceDire;
    public float SlowContor;//减慢因子
    public float ChaseFaceDire;


    [Header("Timer")]
    public float CurrWaitTime;
    public float WaitTimeContor;
    public float ChaseWaitTime;
    public float PotalWaitTime;
    public bool IsWait;
    public Timer WaitTimer;

    [Header("State")]
    public EnemyBaseState CurrState;
    public EnemyBaseState PatrolState;
    public EnemyBaseState ChaseState;
    public EnemyBaseState AttackState;
    public EnemyBaseState DeathState;
    public EnemyBaseState BackState;
    public EnemyBaseState StaticState;

    [Header("ToCheckPlayer")]
    public Vector2 CenterOffist;  //中心点偏移
    public Vector2 CheckSize;  //发射体大小
    public float CheckDisent;   //探测距离
    public LayerMask Player;    //检测图层
    public float ChaseTime;   //追击时间
    public float ChaseTimeContor; //追击时间控制器

    [Header("Jump")]
    public float JumpFouse;

    [Header("ToCheckColl")]
    public bool IsColl = false;

    [Header("Heath")]
    public NewMushroomHealth health;

    [Header("Fly")]
    public Transform StaticPostionInRotationWorld;
    public Vector3 StaticPostion;
    public Vector3 Target;
    public Vector3 MoveDir;
    public float CheckFindPlayerRadios;
    public float CheckFindAttackRadios;
    public float AttackAddRadios;
    public Vector3 LastPostionBeforeAttack;
    public bool IsAttack;
    public Vector3 MoveDirBrforeAttack;
    public float X, Y, Z;

    protected virtual void Awake()
    {
        Cupidd = GameObject.Find("Cupid");
        CupidTransform=Cupidd.transform;
        rb = GetComponent<Rigidbody2D>();
        CheckOfTouch = GetComponent<PychicsCheck>();
        WaitTimer = GetComponent<Timer>();
        health = GetComponent<NewMushroomHealth>();
        SlowContor = 1f;
        EnemyMaster.Instance.AddEnemy(this);
        Debug.Log("EnemyMangerAwake");
        IsAttack = false;
    }

    protected virtual void OnEnable()
    {
        CurrState = PatrolState;
        CurrState.OnEnter(this);
        WaitTimer.Set_Timer(CurrWaitTime, CurrWaitTime + 1f);
        WaitTimer.onComplete += TurnFacedir;
        TimeManager.Instance.AddTimer(WaitTimer);
    }

    private void Update()
    {
        FaceDire = new Vector3(-transform.localScale.x, 0, 0);  //朝向
        CurrState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {

        CurrState.PhysicsUpdate();
    }

    private void OnDisable()
    {
        CurrState.OnExit();
        EnemyMaster.Instance.RemoveEnemy(this);
    }

    public virtual void Move()
    {
        rb.velocity = new Vector2(FaceDire.x * CurrSpeed * Time.deltaTime * SlowContor, rb.velocity.y);
    }

    public virtual void TurnFacedir()
    {
        transform.localScale = new Vector3(FaceDire.x, 1, 1);
        //float timef = 1f;
        //timef-= Time.deltaTime; 
        IsWait = false;

    }


    public virtual bool Lfindplayer()  //检测是否看到player
    {
        //Debug.Log("findplayer333");

        return Physics2D.BoxCast(transform.position + (Vector3)CenterOffist, CheckSize, 0, FaceDire, CheckDisent, Player);
    }

    public void TimeContor()
    {
        if (!Findplayer())
        {
            ChaseTimeContor -= Time.deltaTime;
        }
        else
        {
            ChaseTimeContor = ChaseTime;
        }
    }


    public virtual bool Findplayer()
    {
        if (Lfindplayer() || IsColl)
        {
            IsColl = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual bool TouchWallCheck()
    {
        if ((CheckOfTouch.onRightWall && FaceDire.x > 0) || (CheckOfTouch.onLeftWall && FaceDire.x < 0) || (!CheckOfTouch.onLeftGround && FaceDire.x < 0) || (!CheckOfTouch.onRightGround && FaceDire.x > 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SwithState(EnemyMushroomEnums state)
    {
        var NewState = state switch
        {
            EnemyMushroomEnums.Patol => PatrolState,
            EnemyMushroomEnums.Chase => ChaseState,
            EnemyMushroomEnums.Death => DeathState,
            EnemyMushroomEnums.Static => StaticState,
            EnemyMushroomEnums.Attack => AttackState,
            EnemyMushroomEnums.Back => BackState,
            _ => null
        };

        CurrState.OnExit();
        CurrState = NewState;
        CurrState.OnEnter(this);

    }

    public bool SameLevelCheck()
    {
        float TmpDifferInHeight = transform.position.y - CupidTransform.position.y;
        float v = Mathf.Abs(TmpDifferInHeight);
        float DifferInHeight = v;
        if (DifferInHeight < 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Slow()
    {
        SlowContor = 0.5f;
    }

    public void Stop()
    {
        SlowContor = 0f;
    }
    public void BackTo()
    {
        SlowContor = 1f;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + CenterOffist + new Vector2(CheckDisent * -transform.localScale.x, 0), 0.2f);
    }

    public virtual bool FindAttack()
    {
        return true;
    }
    public bool BackToPor()
    {
        if ((transform.position - StaticPostionInRotationWorld.position).sqrMagnitude < 0.01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void WaitForTwo()
    {
        Invoke("TurnBack", 0.1f);
    }

    public void TurnBack()
    {
        transform.position = LastPostionBeforeAttack + new Vector3(X * AttackAddRadios, AttackAddRadios * Y, 0);
        Invoke("CoolDown", 1f);

    }
    public void CoolDown()
    {

        IsAttack = false;

    }
}



