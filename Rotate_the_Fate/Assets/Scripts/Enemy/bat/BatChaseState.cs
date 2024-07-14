using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatChaseState : BatBaseState
{
    public override void OnEnter(BatManger tmpbat)
    {
        Debug.Log("½øÈë×·");
        currbat = tmpbat;
        currbat.currspeed=currbat.chasespeed;
        currbat.currfaceDir=currbat.CuipdPlay.transform.position;
    }
    public override void Logicupdate()
    {
        if(currbat.chasetimeCon<=0)
        {
            currbat.Swithstate(BatStateEnum.back);
        }
        if (currbat.findAttack())
        {
            currbat.Swithstate(BatStateEnum.attack);
        }
    }



    public override void pythicupdate()
    {
        currbat.Move();
    }

    public override void OnExit()
    {

    }
}
