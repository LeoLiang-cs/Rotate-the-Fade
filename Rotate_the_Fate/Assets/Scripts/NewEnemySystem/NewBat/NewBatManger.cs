using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBatManger : EnemyManger
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        ChaseState=new NewBatChaseState();
        AttackState=new NewBatAttackState();
        BackState=new NewBatBackState();
        StaticState=new NewBatStaticState();
    }

    protected override void OnEnable()
    {
        CurrState = StaticState;
        CurrState.OnEnter(this);

    }

    public override void Move()
    {
        rb.velocity=MoveDir*CurrSpeed*Time.deltaTime;
    }

    public override bool Findplayer()
    {
        float Distent=(transform.position-CupidTransform.position).sqrMagnitude;
        if (Distent < CheckFindPlayerRadios)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool FindAttack()
    {
        float Distent = (transform.position - CupidTransform.position).sqrMagnitude;
        if (Distent < CheckFindAttackRadios+AttackAddRadios)
        {
            return true;
        }
        else
        {
            return false;
        }

    }





}
