using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPatrolState : EnemyBaseState
{

    public MushroomPatrolState(Animator anim)
    {
        this.anim = anim;
    }

    public override void OnEnter(EnemyManger enemy)
    {
        // base.OnEnter(enemy);
        currentEnemy = enemy;
        
        currentEnemy.CurrSpeed = currentEnemy.PatrolSpeed;
        currentEnemy.CurrWaitTime = currentEnemy.PotalWaitTime;
        currentEnemy.WaitTimeContor=currentEnemy.CurrWaitTime;
        if (currentEnemy.IsWait)
        {
            currentEnemy.WaitTimer.Set_CoolDown(currentEnemy.CurrWaitTime);
        }
        else
        {
            currentEnemy.WaitTimer.Set_Timer(currentEnemy.CurrWaitTime, currentEnemy.CurrWaitTime + 1f);
        }
    }

    public override void LogicUpdate()
    {
        if (currentEnemy.health.isDead)
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Death);
        }
        if (currentEnemy.Findplayer())
        {
            //Debug.Log("findplayer");

            currentEnemy.SwithState(EnemyMushroomEnums.Chase);
        }
        if (currentEnemy.TouchWallCheck())
        {
            //Debug.Log("findthedoll"+currenemy.pytcheck.isOngroud);
            if (!currentEnemy.IsWait)
            {
                anim.SetBool("Run", false);
                currentEnemy.WaitTimer.Reset();
                currentEnemy.IsWait = true;
            }

        }
    }




    public override void PhysicsUpdate()
    {
       if(!currentEnemy.IsWait)
        {
            currentEnemy.Move();
        }
    }

    public override void OnExit()
    {
        
    }


}
