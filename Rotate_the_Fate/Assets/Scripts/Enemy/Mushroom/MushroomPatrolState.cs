using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPatrolState : Basestate
{
 
    public override void OnEnter(Enemy enmy)
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
            currenemy.Swithstate(Mushroom_stateEnum.chase);
        }
        if ((currenemy.checktouch.isrighthall&&currenemy.faceDire.x<0) || (currenemy.checktouch.islefthall&&currenemy.faceDire.x>0))
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
