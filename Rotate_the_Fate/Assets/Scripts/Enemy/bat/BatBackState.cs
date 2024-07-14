using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBackState : BatBaseState
{
    public override void OnEnter(BatManger tmpbat)
    {
        Debug.Log("½øÈëback");
        currbat = tmpbat;
        currbat.currspeed = currbat.backspeed;
        currbat.currfaceDir=currbat.priLocation;
    }
    public override void Logicupdate()
    {
        if (currbat.BackToPor())
        {
            currbat.Swithstate(BatStateEnum.staic);
        }
        if (currbat.findplayer())
        {
            currbat.Swithstate(BatStateEnum.chase);
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
        Debug.Log("Àë¿ªbanck");
    }
}
