using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LizardBaseState
{
    protected Liz currenemy;
    public abstract void OnEnter(Liz enmy);

    public abstract void Logicupdate();


    public abstract void pythicupdate();





    public abstract void OnExit();
}
