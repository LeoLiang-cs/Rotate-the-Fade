using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapse = 0f; // after last invoked
    private float cool_down; // cool down time
    private Action onComplete; // do something when cool down end
    private bool frozen = false; // time frozen
    public Action action;

    // public bool IsCooldownComplete(float current_time)
    // {
    //     return (current_time - lastTriggerTime) >= duration;
    // }
    private void Update() {
        if(!frozen){
            elapse += Time.deltaTime;
        }
    }
    private void OnDestroy() {
        onComplete = null;
        action = null;
    }

    public void Set_Timer(float duration){
        cool_down = duration;
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
}

