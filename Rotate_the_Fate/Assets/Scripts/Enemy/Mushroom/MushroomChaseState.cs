using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomChaseState : Basestate
{
    public float chasefair;
    // Start is called before the first frame update
    public override void Logicupdate()
    {
        if (currenemy.chatimecontor <= 0)
        {
            currenemy.Swithstate(Mushroom_stateEnum.potal);
        }
        currenemy.PostioninMushJump();
        if ((currenemy.checktouch.isrighthall && currenemy.faceDire.x > 0) || (currenemy.checktouch.islefthall && currenemy.faceDire.x < 0) || (!currenemy.pytcheck.isOngroud && currenemy.faceDire.x < 0))
        {
            currenemy.iswait = true;

        }
        currenemy.Timecontor();
        if (currenemy.transform.position.y - currenemy.MushchaseCupid.transform.position.y < 1f && currenemy.transform.position.y - currenemy.MushchaseCupid.transform.position.y > -1f)
        {


            if (currenemy.MushchaseCupid.transform.position.x - currenemy.transform.position.x < 0)
            {
                chasefair = 1;
            }
            else if (currenemy.MushchaseCupid.transform.position.x - currenemy.transform.position.x > 0)
            {
                chasefair = -1;
            }
            currenemy.transform.localScale = new Vector3(chasefair, 1, 1);
            currenemy.faceDire.x = -chasefair;
        }
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
        if (currenemy.pytcheck.isOngroud || !currenemy.iswait)
        {
            Debug.Log("walk");
            currenemy.move();
        }

    }
}
