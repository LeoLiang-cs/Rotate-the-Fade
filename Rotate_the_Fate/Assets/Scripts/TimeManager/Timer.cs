using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapse; // after last invoked
    private float cool_down; // cool down time
    public Action onComplete; // do something when cool down end
    private bool frozen = false; // time frozen
    public Action action;

    // public bool IsCooldownComplete(float current_time)
    // {
    //     return (current_time - lastTriggerTime) >= duration;
    // }
    private void Update() {
        if(!frozen){
            if(elapse < cool_down){
                elapse += Time.deltaTime;
                if(elapse >= cool_down) onComplete?.Invoke();
            }else{
                elapse += Time.deltaTime;
            }
        }else{
            // Debug.Log("Frozen Timer");
        }
    }
    private void OnDestroy() {
        onComplete = null;
        action = null;
    }

    public void Set_Timer(float duration, float init_elps){
        cool_down = duration;
        elapse = init_elps;
    }

    public void Trigger(){
        if(elapse < cool_down || frozen) return;
        // do something
        action?.Invoke();
        elapse = 0f;
    }

    public void Freeze(){
        frozen = true;
    }

    public void Resume(){
        frozen = false;
    }

    public void Reset(){
        //Debug.Log(onComplete);
        elapse = 0f;
    }

    public void Set_CoolDown(float new_cd){
        elapse = 0f;
        cool_down = new_cd;
    }
}

