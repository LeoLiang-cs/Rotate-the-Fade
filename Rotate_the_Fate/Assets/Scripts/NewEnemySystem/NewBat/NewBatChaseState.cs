using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBatChaseState : EnemyBaseState
{
    public NewBatChaseState(Animator anim,BatHealth health)
    {
        this.anim = anim;
        Health = health;
    }
    public override void OnEnter(EnemyManger enemy)
    {

        Debug.Log("enterChase");
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = currentEnemy.ChaseSpeed;
        currentEnemy.ChaseTimeContor = currentEnemy.ChaseWaitTime;
        anim.SetBool("Fly", true);

    }
    
public override void LogicUpdate()
    {
        currentEnemy.MoveDirBrforeAttack = (currentEnemy.transform.position - currentEnemy.CupidTransform.position).normalized;
        if (currentEnemy.MoveDirBrforeAttack.x > 0)
        {
            currentEnemy.X = 1;
        }
        else if(currentEnemy.MoveDirBrforeAttack.x<0)
        {
            currentEnemy.X = -1;
        }
        if (currentEnemy.MoveDirBrforeAttack.y < 0)
        {
            currentEnemy.Y = -1;
        }
        else if (currentEnemy.MoveDirBrforeAttack.y > 0)
        {
            currentEnemy.Y = 1;
        }
        if (currentEnemy.FindAttack())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Attack);
        }
        currentEnemy.TimeContor();
        if (currentEnemy.ChaseTimeContor <= 0)
        {
          
            currentEnemy.SwithState(EnemyMushroomEnums.Back);
        }
        
      
        currentEnemy.Target = currentEnemy.CupidTransform.position;
        currentEnemy.MoveDir = (currentEnemy.Target - currentEnemy.transform.position).normalized;
       

    }

    

   

    public override void PhysicsUpdate()
    {
        if(Health.isHitting)
        {
            currentEnemy.CurrSpeed=0;
        }
        else
        {
            currentEnemy.CurrSpeed = currentEnemy.ChaseSpeed;
        }
        currentEnemy.Move();
    }

    public override void OnExit()
    {
        Debug.Log("exitChase"); 
    }


}
