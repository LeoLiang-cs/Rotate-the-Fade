using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStaicState : BatBaseState
{
    public override void OnEnter(BatManger tmpbat)
    {
        Debug.Log("进入staic");
        currbat = tmpbat;
        currbat.currspeed = currbat.staticspeed;
        currbat.currfaceDir = currbat.priLocation;
    }
    public override void Logicupdate()
    {
        if (currbat.findplayer())
        {
            Debug.Log("出static,进入chase");
            currbat.Swithstate(BatStateEnum.chase);
        }
        if(currbat.findAttack())
        {
            currbat.Swithstate(BatStateEnum.attack);
        }
    }
        


    public override void pythicupdate()
    {
        
    }

    public override void OnExit()
    {
        Debug.Log("出static");
    }
}
