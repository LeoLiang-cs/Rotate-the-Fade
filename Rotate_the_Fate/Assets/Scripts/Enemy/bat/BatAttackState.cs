using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackState :BatBaseState
{

    public override void OnEnter(BatManger tmpbat)
    {
        Debug.Log("进入攻击");
        currbat= tmpbat;
    }

    public override void Logicupdate()
    {
        if (currbat == null)
        {
            Debug.LogError("currbat is null");
            return;
        }
        currbat.transform.localPosition = currbat.CuipdPlay.transform.localPosition;
        Debug.Log("lastpostion" + currbat.lastPostaton);
        currbat.WaitForTwo();
        //GameObject obj = currbat.gameObject;
        //StartCoroutine(MyCoroutine(obj));
        
        //if (currbat.findplayer())
        //{
          
            currbat.Swithstate(BatStateEnum.chase);
        //}
        //if (currbat.chasetimeCon <= 0)
        //{
        //    currbat.Swithstate(BatStateEnum.back);
        //}
    }



    public override void pythicupdate()
    {

    }

    public override void OnExit()
    {
        Debug.Log("离开进攻");
    }
    
    //private IEnumerator MyCoroutine(GameObject BatObj)
    //{
    //    // 协程的执行逻辑
    //    Debug.Log("协程开始");
    //    Debug.Log("一帧后执行");
    //    yield return new WaitForSeconds(2.0f); // 暂停执行2秒钟
    //                                           // 继续执行逻辑
    //    currbat.transform.position = currbat.lastPostaton;
    //}
}
