using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MushroomdeathState : Basestate
{
    
    public override void OnEnter(Enemy enmy)
    {
        currenemy = enmy;
    }
    public override void Logicupdate()
    {
        if (currenemy.health.isDead == true)
        {
            //GetComponent<Animator>().SetTrigger("Death");
            //Destroy(currenemy.gameObject);
            
        }
    }



    public override void pythicupdate()
    {
    
    }
    public override void OnExit()
    {
        
    }



}
