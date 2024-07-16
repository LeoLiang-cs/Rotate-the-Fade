using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMushroomManger : EnemyManger
{
    protected Animator anim;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        PatrolState= new MushroomPatrolState(anim);
        ChaseState = new MushroomChaseState(anim);
        DeathState=new MushroomDeathState(anim);
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void TurnFacedir()
    {
        base.TurnFacedir();
        anim.SetBool("Run", true);
    }



}
