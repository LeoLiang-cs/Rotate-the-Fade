using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDeathState : EnemyBaseState
{
    public MushroomDeathState(Animator anim)
    {
        this.anim = anim;
    }
    public override void OnEnter(EnemyManger enemy)
    {
        base.OnEnter(enemy);
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
