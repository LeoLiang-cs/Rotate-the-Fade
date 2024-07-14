using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MushroomdeathState : BaseState
{
    
    public override void OnEnter(Enemy enmy)
    {
        currentEnemy = enmy;
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.health.isDead == true)
        {
            //GetComponent<Animator>().SetTrigger("Death");
            //Destroy(currenemy.gameObject);
            
        }
    }



    public override void PhysicsUpdate()
    {
    
    }
    public override void OnExit()
    {
        
    }



}
