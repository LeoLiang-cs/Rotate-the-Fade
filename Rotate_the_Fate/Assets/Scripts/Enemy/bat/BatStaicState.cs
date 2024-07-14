using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStaicState : BatBaseState
{
    public override void OnEnter(BatManger tmpbat)
    {
        currbat = tmpbat;
        currbat.currspeed = currbat.staticspeed;
        currbat.currfaceDir = currbat.priLocation;
        currbat?.GetComponent<Animator>().SetBool("Fly", false);
    }
    public override void Logicupdate()
    {
        if (currbat.findplayer())
        {
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

    }
}
