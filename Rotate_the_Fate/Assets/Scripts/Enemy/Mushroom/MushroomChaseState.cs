using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomChaseState : BaseState
{
    public float chasefair;
    // Start is called before the first frame update
    public override void LogicUpdate()
    {
        if (currentEnemy.health.isDead)
        {
            currentEnemy.Swithstate(Mushroom_stateEnum.death);
        }
        if (currentEnemy.chatimecontor <= 0)
        {
            currentEnemy.Swithstate(Mushroom_stateEnum.potal);
        }
        currentEnemy.PostioninMushJump();
        if ((currentEnemy.checktouch.onRightWall && currentEnemy.faceDire.x > 0) || (currentEnemy.checktouch.onLeftWall && currentEnemy.faceDire.x < 0) || (!currentEnemy.pytcheck.onGround && currentEnemy.faceDire.x < 0))
        {
            if (!currentEnemy.iswait)
            {
                currentEnemy.waitTimer.Reset();
                currentEnemy.iswait = true;
            }

        }
        currentEnemy.Timecontor();
        if (currentEnemy.transform.position.y - currentEnemy.MushchaseCupid.transform.position.y < 1f && currentEnemy.transform.position.y - currentEnemy.MushchaseCupid.transform.position.y > -1f)
        {


            if (currentEnemy.MushchaseCupid.transform.position.x - currentEnemy.transform.position.x < 0)
            {
                chasefair = 1;
            }
            else if (currentEnemy.MushchaseCupid.transform.position.x - currentEnemy.transform.position.x > 0)
            {
                chasefair = -1;
            }
            currentEnemy.transform.localScale = new Vector3(chasefair, 1, 1);
            currentEnemy.faceDire.x = -chasefair;
        }
        //chaseFarid();
    }
    private void chaseFarid()
    {
        currentEnemy.faceDire=currentEnemy.MushchaseCupid.transform.position;
    }

    public override void OnEnter(Enemy enmy)
    {
        //Debug.Log("enterchase");
        currentEnemy = enmy;
        currentEnemy.currspeed = currentEnemy.chasespeed;
        currentEnemy.currwaittime = currentEnemy.chasewaitime;
        currentEnemy.waitcontor = currentEnemy.currwaittime;
        if (currentEnemy.iswait)
        {
            currentEnemy.waitTimer.Set_CoolDown(currentEnemy.currwaittime);
        }
        else
        {
            currentEnemy.waitTimer.Set_Timer(currentEnemy.currwaittime, currentEnemy.currwaittime + 1f);
        }
    }

    public override void OnExit()
    {
        currentEnemy.chatimecontor = currentEnemy.chatime;
    }

    public override void PhysicsUpdate()
    {
        if (currentEnemy.pytcheck.onGround || !currentEnemy.iswait)
        {
            //Debug.Log("walk");
            currentEnemy.move();
        }

    }
}
