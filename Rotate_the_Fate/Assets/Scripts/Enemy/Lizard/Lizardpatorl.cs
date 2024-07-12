using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizardpatorl : LizardBaseState
{
    public override void OnEnter(Liz enmy)
    {
        Debug.Log("inpotalstate");
        currenemy = enmy;
        currenemy.currspeed = currenemy.normalspeed;
        currenemy.currwaittime = currenemy.potalwaittime;
        currenemy.waitcontor = currenemy.currwaittime;
    }
    public override void Logicupdate()
    {
        if (currenemy.findplayer())
        {
            Debug.Log("findplayer");
            currenemy.Swithstate(LizardStateEnum.chase);
        }
        if ((currenemy.checktouch.isrighthall && currenemy.faceDire.x > 0) || (currenemy.checktouch.islefthall && currenemy.faceDire.x < 0))
        {
            Debug.Log("findthedoll");
            currenemy.iswait = true;
        }
        currenemy.Timecontor();
    }

    public override void pythicupdate()
    {
        currenemy.move();
    }

    public override void OnExit()
    {

    }
}
