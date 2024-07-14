using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BatBaseState : MonoBehaviour
{
    public BatManger currbat;
    public abstract void OnEnter(BatManger tmpbat);

    public abstract void Logicupdate();


    public abstract void pythicupdate();





    public abstract void OnExit();
}
