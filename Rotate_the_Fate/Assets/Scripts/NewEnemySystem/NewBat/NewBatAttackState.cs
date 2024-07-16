using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBatAttackState : EnemyBaseState
{

    public NewBatAttackState(Animator anim)
    {
        this.anim = anim;
    }
    public override void OnEnter(EnemyManger enemy)
    {
        Debug.Log("EnterAttack");
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = 0f;
    }
    public override void LogicUpdate()
    {
        currentEnemy.transform.position=currentEnemy.CupidTransform.position;
        currentEnemy.WaitForTwo();
        currentEnemy.SwithState(EnemyMushroomEnums.Chase);
    }

    

    

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnExit()
    {
        Debug.Log("ExitAttack");
    }


}
