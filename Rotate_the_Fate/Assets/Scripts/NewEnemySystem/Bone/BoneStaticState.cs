using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneStaticState : EnemyBaseState
{
public BoneStaticState(Animator anim)
    {
        this.anim = anim;
    }
    public override void OnEnter(EnemyManger enemy)
    {
        // Debug.Log("enterStatic");
        currentEnemy = enemy;
        currentEnemy.CurrSpeed = 0f;
        currentEnemy.Target = currentEnemy.StaticPostion;

    }
    public override void LogicUpdate()
    {
        //currentEnemy.transform.position = currentEnemy.StaticPostionInRotationWorld.position;
        //currentEnemy.transform.position=currentEnemy.StaticPostion;
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
        currentEnemy.Move();
    }

    public override void OnExit()
    {
        // Debug.Log("exitStatic");
    }
}
