using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBatStaticState : EnemyBaseState
{

    public override void OnEnter(EnemyManger enemy)
    {
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = 0f;
        currentEnemy.Target = currentEnemy.StaticPostion;

    }
    public override void LogicUpdate()
    {
        if (currentEnemy.Findplayer())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Chase);
        }
        if (currentEnemy.FindAttack())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Attack);
        }
    }

    

    

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnExit()
    {
        
    }

    // Start is called before the first frame update

}
