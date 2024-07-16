using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowState : EnmybeahiorBasestate
{
    public override void OnEnter(EnemyManger tmpEnmy)
    {
        Enmy=tmpEnmy;
        //Enmy.enmystype.slowcl = 0.5f;
    }
    public override void Logicupdate()
    {
        //Enmy.enmystype.slowcl = 0.5f;
    }



    public override void pythicupdate()
    {
        
    }

    public override void OnExit()
    {
        
    }
}
