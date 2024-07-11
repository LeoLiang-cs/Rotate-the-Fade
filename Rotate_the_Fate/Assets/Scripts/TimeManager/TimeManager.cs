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
    private bool isTimePaused = false;

    public void AddTimer(Timer timer)
    {
        timers.Add(timer);
    }

    public void RemoveTimer(Timer timer)
    {
        timers.Remove(timer);
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

    public void PauseTime(Timer timer)
    {
        FreezeTimers(timer);
        isTimePaused = true;
    }

    public void ResumeTime()
    {
        isTimePaused = false;
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
