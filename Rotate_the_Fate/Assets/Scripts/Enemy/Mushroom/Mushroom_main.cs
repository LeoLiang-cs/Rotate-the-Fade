using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Mushroom : Enemy
{
    public GameObject MushchaseCupid;
    public Inputall MushroomJumpFllow;

    [Header("µ±Ç°CupidÎ»ÖÃ")]
    public Vector2 Cupidpostion;
    public bool LastisJump;

    private void Awake()
    {
        //potalstate = new MushroomPatrolState();
        //chasestate = new MushroomChaseState();
        MushroomJumpFllow = new Inputall();
        MushroomJumpFllow.Game.CupidJump.started += ISMushroomJump;
        MushchaseCupid = GameObject.Find("Cupid");
        LastisJump = false;
    }
    private void ISMushroomJump(CallbackContext context)
    {
        Cupidpostion = new Vector2(MushchaseCupid.transform.position.x, MushchaseCupid.transform.position.y);
        LastisJump = true;

    }
    public void PostioninMushJump()
    {
        Vector2 MushPostion = new Vector2(transform.position.x, transform.position.y);
        if (LastisJump && MushPostion == Cupidpostion)
        {
            Jump();
            LastisJump=false;
        }
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
