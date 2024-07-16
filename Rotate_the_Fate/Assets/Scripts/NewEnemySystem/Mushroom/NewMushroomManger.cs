using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMushroomManger : EnemyManger
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        PatrolState= new MushroomPatrolState();
        ChaseState = new MushroomChaseState();
        DeathState=new MushroomDeathState();
    }



}
