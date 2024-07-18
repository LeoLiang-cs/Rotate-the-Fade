using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneManger : EnemyManger
{
       Animator anim;
    BatHealth Health;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Health = GetComponent<BatHealth>();
        anim = GetComponent<Animator>();
        ChaseState = new NewBatChaseState(anim, Health);
        AttackState = new NewBatAttackState(anim);
        BackState = new NewBatBackState(anim);
        StaticState = new BoneStaticState(anim);
        ChaseTimeContor = ChaseTime;
        //StaticPostion = StaticPostionInRotationWorld.position;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Flip();
    }

    protected override void OnEnable()
    {
        CurrState = StaticState;
        CurrState.OnEnter(this);
    }

    public override void Move()
    {
        rb.velocity = MoveDir * CurrSpeed * Time.deltaTime * SlowContor;
    }

    public override bool Findplayer()
    {
        float Distent = (transform.position - CupidTransform.position).sqrMagnitude;
        if (Distent < CheckFindPlayerRadios)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Stop()
    {
        base.Stop();
        anim.speed = 0.0f;
    }

    public override void BackTo()
    {
        base.BackTo();
        anim.speed = 1f;
    }

    public override bool FindAttack()
    {
        float Distent = (transform.position - CupidTransform.position).sqrMagnitude;
        //if (Distent < CheckFindAttackRadios+AttackAddRadios)
        //{
        //    if (!IsAttack)
        //    {
        //        LastPostionBeforeAttack = transform.position;
        //        IsAttack = true;
        //    }

        //}
        if (Distent < CheckFindAttackRadios)
        {
            LastPostionBeforeAttack = transform.position;
            return true;
        }
        else
        {
            return false;
        }

    }
    void Flip()
    {
        if (CupidTransform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public override bool BackToPor()
    {
        return false;
    }


}
