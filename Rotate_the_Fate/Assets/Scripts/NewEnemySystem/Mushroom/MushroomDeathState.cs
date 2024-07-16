using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDeathState : EnemyBaseState
{
    public override void OnEnter(EnemyManger enemy)
    {
        currentEnemy= enemy;
    }

    public override void LogicUpdate()
    {
        if (currentEnemy.health.isDead == true)
        {
            //GetComponent<Animator>().SetTrigger("Death");
            //Destroy(currenemy.gameObject);

        }
    }




    public override void PhysicsUpdate()
    {
        
    }
    public override void OnExit()
    {
        
    }

}
