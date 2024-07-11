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
        currenemy.PostioninMushJump();
        if ((currenemy.checktouch.isrighthall && currenemy.faceDire.x < 0) || (currenemy.checktouch.islefthall && currenemy.faceDire.x > 0))
        {
            currenemy.iswait = true;

        }
        currenemy.Timecontor();
        //chaseFarid();
    }
    private void chaseFarid()
    {
        currenemy.faceDire=currenemy.MushchaseCupid.transform.position;
    }

    public override void OnEnter(Enemy enmy)
    {
        Debug.Log("enterchase");
        currenemy = enmy;
        currenemy.currspeed = currenemy.chasespeed;
        currenemy.currwaittime = currenemy.chasewaitime;
        currenemy.waitcontor = currenemy.currwaittime;
    }

    public override void OnExit()
    {
        currenemy.chatimecontor = currenemy.chatime;
    }

    public override void pythicupdate()
    {
        currenemy.move();
        
    }
}
