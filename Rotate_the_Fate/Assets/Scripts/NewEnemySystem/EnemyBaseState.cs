using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    // Start is called before the first frame update
    protected EnemyManger currentEnemy;
    public virtual void OnEnter(EnemyManger enemy)
    {

    }

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void OnExit();
}
