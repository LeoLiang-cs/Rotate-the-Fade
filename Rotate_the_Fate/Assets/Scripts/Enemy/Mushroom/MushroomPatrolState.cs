using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MushroomPatrolState : BaseState
{
 
    public override void OnEnter(Enemy enmy)
    {
        //Debug.Log("inpotalstate");
        currentEnemy = enmy;
        currentEnemy.currspeed = currentEnemy.normalspeed;
        currentEnemy.currwaittime = currentEnemy.potalwaittime;
        currentEnemy.waitcontor = currentEnemy.currwaittime;
        if (currentEnemy.iswait)
        {
            currentEnemy.waitTimer.Set_CoolDown(currentEnemy.currwaittime);
        }
        else
        {
            currentEnemy.waitTimer.Set_Timer(currentEnemy.currwaittime,currentEnemy.currwaittime+1f);
        }
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.health.isDead)
        {
            currentEnemy.Swithstate(Mushroom_stateEnum.death);
        }
        if (currentEnemy.findplayer())
        {
            //Debug.Log("findplayer");
            currentEnemy.Swithstate(Mushroom_stateEnum.chase);
        }
        if ((currentEnemy.checktouch.onRightWall&&currentEnemy.faceDire.x>0) || (currentEnemy.checktouch.onLeftWall&&currentEnemy.faceDire.x<0)||(!currentEnemy.pytcheck.onGround&&currentEnemy.faceDire.x<0))
        {
            //Debug.Log("findthedoll"+currenemy.pytcheck.isOngroud);
            if (!currentEnemy.iswait)
            {
                currentEnemy.waitTimer.Reset();
                currentEnemy.iswait = true;
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

    

    public override void PhysicsUpdate()
    {
        if (currentEnemy.pytcheck.onGround||!currentEnemy.iswait)
        {
            //Debug.Log("walk");
            currentEnemy.move();
        }
    }

    public override void OnExit()
    {
        
    }
}
