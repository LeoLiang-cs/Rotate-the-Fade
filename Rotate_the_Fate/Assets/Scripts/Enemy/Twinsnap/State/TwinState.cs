using UnityEngine;

public abstract class TwinState : MonoBehaviour
{
    protected TwinBehavior currentEnemy;
    public abstract void OnEnter(TwinBehavior twinSnap);

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();

    public abstract void OnExit();
}

