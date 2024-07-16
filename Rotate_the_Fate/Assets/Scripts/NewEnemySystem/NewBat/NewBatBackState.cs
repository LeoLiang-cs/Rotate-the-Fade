using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBatBackState : EnemyBaseState
{
    public NewBatBackState(Animator anim)
    {
        this.anim = anim;
    }
    public override void OnEnter(EnemyManger enemy)
    {
        Debug.Log("enterBack");
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = currentEnemy.PatrolSpeed;
    }
    public override void LogicUpdate()
    {
        currentEnemy.Target = currentEnemy.StaticPostion;
        Debug.Log("StaticPostion" + currentEnemy.StaticPostion);
        currentEnemy.MoveDir = (currentEnemy.StaticPostionInRotationWorld.position - currentEnemy.transform.position).normalized;
        Debug.Log("movedir"+currentEnemy.MoveDir);
        currentEnemy.MoveDirBrforeAttack = (currentEnemy.transform.position - currentEnemy.CupidTransform.position).normalized;
        if (currentEnemy.MoveDirBrforeAttack.x > 0)
        {
            currentEnemy.X = 1;
        }
        else if (currentEnemy.MoveDirBrforeAttack.x < 0)
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
        if (currentEnemy.BackToPor())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Static);
        }
        if (currentEnemy.Findplayer())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Chase);
        }
        if(currentEnemy.FindAttack())
        {
            currentEnemy.SwithState(EnemyMushroomEnums.Attack);
        }
    }

    

   

    public override void PhysicsUpdate()
    {
        currentEnemy.Move();
    }
    public override void OnExit()
    {

        Debug.Log("ExitBack");
    }

    // Start is called before the first frame update

}
