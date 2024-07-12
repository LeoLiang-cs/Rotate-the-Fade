using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMangerBasestate : MonoBehaviour
{
    public EnemyManger Enmy;
    // Start is called before the first frame update
    public EnmybeahiorBasestate currState;
    public EnmybeahiorBasestate slowdown;
    public EnmybeahiorBasestate stopin;
    public EnmybeahiorBasestate Back;
    //public void Swithstate(EnemybeachiorEnums state)
    //{
    //    var newstate = state switch
    //    {
    //        EnemybeachiorEnums.stop => stopin,
    //        EnemybeachiorEnums.slow => slowdown,
    //        EnemybeachiorEnums.backtoNormal=>Back,
    //        _ => null
    //    } ;
    //    currState.OnExit();
    //    currState = newstate;
    //    currState.OnEnter(this);
    //}
    public abstract void OnEnter(EnemyManger tmpenmy);

    public abstract void Logicupdate();


    public abstract void pythicupdate();





    public abstract void OnExit();
}
