using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MushroomPatrolState : Basestate
{
 
    public override void OnEnter(Enemy enmy)
    {
        Debug.Log("inpotalstate");
        currenemy = enmy;
        currenemy.currspeed = currenemy.normalspeed;
        currenemy.currwaittime = currenemy.potalwaittime;
        currenemy.waitcontor = currenemy.currwaittime;
        if (currenemy.iswait)
        {
            currenemy.waitTimer.Set_CoolDown(currenemy.currwaittime);
        }
        else
        {
            currenemy.waitTimer.Set_Timer(currenemy.currwaittime,currenemy.currwaittime+1f);
        }
    }
    public override void Logicupdate()
    {
        if (currenemy.findplayer())
        {
            Debug.Log("findplayer");
            currenemy.Swithstate(Mushroom_stateEnum.chase);
        }
        if ((currenemy.checktouch.isrighthall&&currenemy.faceDire.x>0) || (currenemy.checktouch.islefthall&&currenemy.faceDire.x<0)||(!currenemy.pytcheck.isOngroud&&currenemy.faceDire.x<0))
        {
            Debug.Log("findthedoll"+currenemy.pytcheck.isOngroud);
            if (!currenemy.iswait)
            {
                currenemy.waitTimer.Reset();
                currenemy.iswait = true;
            }
            
        }

        //nogroud();
        //currenemy.Timecontor();
    }

    //public void nogroud()
    //{
    //    if (currenemy.faceDire.x < 0)
    //    {
    //        if (!currenemy.pytcheck.isOngroud && currenemy.faceDire.x < 0)
    //        {
                
    //            currenemy.waitcontor -= Time.deltaTime;
    //            if (currenemy.waitcontor <= 0)
    //            {

    //                currenemy.waitcontor = 100f;

    //                currenemy.transform.localScale = new Vector3(currenemy.faceDire.x, 1, 1);
    //                float timef = 1f;
    //                timef -= Time.deltaTime; 
                    

    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (!currenemy.pytcheck.isOngroud && currenemy.faceDire.x > 0)
    //        {
                
    //            currenemy.waitcontor -= Time.deltaTime;
    //            if (currenemy.waitcontor <= 0)
    //            {

    //                currenemy.waitcontor = 100f;

    //                currenemy.transform.localScale = new Vector3(currenemy.faceDire.x, 1, 1);
    //                float timef = 1f;
    //                timef -= Time.deltaTime;


    //            }
    //        }
    //    }
    //}

    

    public override void pythicupdate()
    {
        if (currenemy.pytcheck.isOngroud||!currenemy.iswait)
        {
            Debug.Log("walk");
            currenemy.move();
        }
    }

    public override void OnExit()
    {
        
    }
}
