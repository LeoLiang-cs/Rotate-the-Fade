using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnmybeahiorBasestate : MonoBehaviour
{
    public EnemyManger Enmy;
    public abstract void OnEnter(EnemyManger tmpEnmy);

    public abstract void Logicupdate();


    public abstract void pythicupdate();





    public abstract void OnExit();
}
