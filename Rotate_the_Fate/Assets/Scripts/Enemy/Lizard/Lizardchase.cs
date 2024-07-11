using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizardchase : LizardBaseState
{
    public float chasefair;
    public override void Logicupdate()
    {
        if (currenemy.chatimecontor <= 0)
        {
            currenemy.Swithstate(LizardStateEnum.potal);
        }
        currenemy.PostioninMushJump();
        if ((currenemy.checktouch.isrighthall && currenemy.faceDire.x > 0) || (currenemy.checktouch.islefthall && currenemy.faceDire.x < 0))
        {
            currenemy.iswait = true;

        }
        currenemy.Timecontor();
        //chaseFarid();
        if (currenemy.transform.position.y-currenemy.LizardchaseCupid.transform.position.y<1f && currenemy.transform.position.y - currenemy.LizardchaseCupid.transform.position.y>-1f)
        {


            if (currenemy.LizardchaseCupid.transform.position.x - currenemy.transform.position.x < 0)
            {
                chasefair = 1;
            }
            else if (currenemy.LizardchaseCupid.transform.position.x - currenemy.transform.position.x > 0)
            {
                chasefair = -1;
            }
            currenemy.transform.localScale = new Vector3(chasefair, 1, 1);
            currenemy.faceDire.x = -chasefair;
        }
    }
    private void chaseFarid()
    {
        currenemy.faceDire = currenemy.LizardchaseCupid.transform.position;
    }

    public override void OnEnter(Liz enmy)
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
