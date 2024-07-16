using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    private static TimeManager instance;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimeManager();
            }
            return instance;
        }
    }

    private List<Timer> timers = new List<Timer>();
    private List<IStoppable> stoppables = new List<IStoppable>();
    private bool isTimePaused = false;

    public void AddTimer(Timer timer)
    {
        timers.Add(timer);
    }

    public void RemoveTimer(Timer timer)
    {
        timers.Remove(timer);
    }

    public void AddStoppable(IStoppable stoppable)
    {
        stoppables.Add(stoppable);
    }

    public void RemoveStoppable(IStoppable stoppable)
    {
        stoppables.Remove(stoppable);
    }

    public void FreezeTimers(Timer timer)
    {
        if (isTimePaused) return;

        foreach (var timerObj in timers)
        {
            if(timerObj != timer){
                timerObj.Freeze();
            }
        }
    }

    private void FreezeStoppable(){
        foreach (var stoppable in stoppables)
        {
            stoppable.Stop();
        }
    }

    private void ResumeStoppable(){
        foreach (var stoppable in stoppables)
        {
            stoppable.BackTo();
        }
    }

    public void PauseTime(Timer timer)
    {
        FreezeTimers(timer);
        FreezeStoppable();
        EnemyMaster.Instance.Freeze();
        isTimePaused = true;
    }

    public void ResumeTime()
    {
        isTimePaused = false;
        EnemyMaster.Instance.Resume();
        ResumeStoppable();
        foreach (var timerObj in timers)
        {
            timerObj.Resume();
        }
    }

    // public void Update()
    // {
    //     UpdateTimers();
    // }
}
