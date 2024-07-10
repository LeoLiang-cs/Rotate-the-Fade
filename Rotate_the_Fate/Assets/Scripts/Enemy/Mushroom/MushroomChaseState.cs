using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomChaseState : Basestate
{
    // Start is called before the first frame update
    public override void Logicupdate()
    {
        if (currenemy.chatimecontor <= 0)
        {
            currenemy.Swithstate(Mushroom_stateEnum.potal);
        }
        if (currenemy.checktouch.isrighthall || currenemy.checktouch.islefthall)
        {
            currenemy.iswait = true;

        }
        currenemy.Timecontor();
    }

    public override void OnEnter(Enemy enmy)
    {
        currenemy = (Mushroom)enmy;
        currenemy.currspeed = currenemy.chasespeed;
        currenemy.currwaittime = currenemy.chasewaitime;
        currenemy.waitcontor = currenemy.currwaittime;
    }

    public override void OnExit()
    {
        currenemy.move();
    }

    public override void pythicupdate()
    {
        currenemy.chatimecontor = currenemy.chatime;
    }
}
