using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackNormalState : EnmybeahiorBasestate
{
    public override void OnEnter(EnemyManger tmpEnmy)
    {
        Enmy = tmpEnmy;
        //Enmy.enmystype.slowcl = 1f;
    }
    public override void Logicupdate()
    {
        //Enmy.enmystype.slowcl = 1f;
    }



    public override void pythicupdate()
    {

    }

    public override void OnExit()
    {

    }
}
