using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopstate : EnmybeahiorBasestate
{
    // Start is called before the first frame update
    public override void OnEnter(EnemyManger tmpEnmy)
    {
        Enmy=tmpEnmy;
        Enmy.enmystype.slowcl = 0f;
    }
    public override void Logicupdate()
    {
        //Enmy.enmystype.slowcl = 0f;
    }



    public override void pythicupdate()
    {
       
    }

    public override void OnExit()
    {
       
    }
}
