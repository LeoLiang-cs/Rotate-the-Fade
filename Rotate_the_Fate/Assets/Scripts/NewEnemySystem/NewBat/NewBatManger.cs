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
        ChaseTimeContor = ChaseTime;
        StaticPostion = StaticPostionInRotationWorld.position;
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
        Debug.Log("UseFindplayerOfBat");
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
        Debug.Log("UseFindAttAckOfBat");
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





}
