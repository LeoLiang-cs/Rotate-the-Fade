using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    private void Awake()
    {
        potalstate = new MushroomPatrolState();
        chasestate = new MushroomChaseState();
    }
    private void OnEnable()
    {
        currstate = potalstate;
        currstate.OnEnter(this);
    }
    public void Swithstate(Mushroom_stateEnum state)
    {
        var newstate = state switch
        {
            Mushroom_stateEnum.potal => potalstate,
            Mushroom_stateEnum.chase => chasestate,
            Mushroom_stateEnum.attack=>attckstate,
            Mushroom_stateEnum.death => deathstate,
            Mushroom_stateEnum.force=>Forcestate,
            _ => null
        };
        currstate.OnExit();
        currstate = newstate;
        currstate.OnEnter(this);
    }
}
