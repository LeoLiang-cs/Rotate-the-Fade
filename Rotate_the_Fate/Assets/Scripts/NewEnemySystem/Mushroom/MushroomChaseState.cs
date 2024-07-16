using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomChaseState : EnemyBaseState
{
    public MushroomChaseState(Animator anim)
    {
        this.anim = anim;
    }

    public override void OnEnter(EnemyManger enemy)
    {
        base.OnEnter(enemy);
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = currentEnemy.ChaseSpeed;
        currentEnemy.CurrWaitTime = currentEnemy.ChaseWaitTime;
        currentEnemy.WaitTimeContor = currentEnemy.CurrWaitTime;
    }
    public override void LogicUpdate()
    {
        Debug.Log("enterpatrol2+ ", currentEnemy.gameObject);
        if (currentEnemy.health.isDead)
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Death);
        }
        if(currentEnemy.ChaseTimeContor<=0)
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Patol);
        }

        //Can Add Jump

        if (currentEnemy.TouchWallCheck())
        {
            if (!currentEnemy.IsWait)
            {
                currentEnemy.WaitTimer.Reset();
                currentEnemy.IsWait = true;
            }
        }
        currentEnemy.TimeContor();
        if(currentEnemy.SameLevelCheck())
        {
            if (currentEnemy.CupidTransform.position.x - currentEnemy.transform.position.x < 0)
            {
                currentEnemy.ChaseFaceDire = 1;
            }
            else if(currentEnemy.CupidTransform.position.x-currentEnemy.transform.position.x > 0)
            {
                currentEnemy.ChaseFaceDire = -1;
            }
            currentEnemy.transform.localScale = new Vector3(currentEnemy.ChaseFaceDire, 1, 1);
            currentEnemy.FaceDire.x = -currentEnemy.ChaseFaceDire;
        }
    }



    

    public override void PhysicsUpdate()
    {
       if(!currentEnemy.TouchWallCheck()) 
        {
            currentEnemy.Move();
        }
    }
    public override void OnExit()
    {
        
    }

  
}
