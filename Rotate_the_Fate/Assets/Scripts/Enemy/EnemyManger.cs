using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyManger : MonoBehaviour
{
    [Header("״̬")]
    public EnmybeahiorBasestate currState;
    public EnemyMangerBasestate MushrommState;
    public EnmybeahiorBasestate slowdown;
    public EnmybeahiorBasestate stopin;
    public EnmybeahiorBasestate Back;

    [Header("怪物")]
    public Enemy enmystype;





    private void Awake()
    {
        MushrommState = GetComponent<EnemyMangerBasestate>();
        enmystype=GetComponent<Enemy>();
        enmystype.slowcl = 1f;
        Debug.Log("xxxxxxxxxxxx  "+this);
        //currState = Back;
        //currState.OnEnter(GetComponent<EnemyManger>());
    }
    //private void OnEnable()
    //{
    //    currState = Back;
    //    currState.OnEnter(this);
    //}

    private void Update()
    {
        //currState.Logicupdate();
    }
    private void OnDisable()
    {
        
    }

    public void Slow()
    {
        enmystype.slowcl = 0.5f;
    }
    public void Stop()
    {
        enmystype.slowcl = 0f;
    }
    public void Backto()
    {
        enmystype.slowcl = 1f;
    }
    //public void Mushroomchange()
    //{
    //    currState = MushrommState;
    //    currState.OnEnter(this);
    //}

    //public void Swithstate(EnemyMangerEnum state)
    //{
    //    var newstate = state switch
    //    {
    //        EnemyMangerEnum.Mushroom => MushrommState,
    //        _ => null
    //    };
    //    currState.OnExit();
    //    currState = newstate;
    //    currState.OnEnter(this);
    //}
    public void Swithstate(EnemybeachiorEnums state)
    {
        var newstate = state switch
        {
            EnemybeachiorEnums.stop => stopin,
            EnemybeachiorEnums.slow => slowdown,
            EnemybeachiorEnums.backtoNormal => Back,
            _ => null
        };
        currState.OnExit();
        currState = newstate;
        currState.OnEnter(this);
    }


}
