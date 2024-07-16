using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SDTimeStop : MonoBehaviour, IStoppable
{
    private SDAttack sdAttack;
    private SDHealth sdHealth;
    private SDBehavior sdBehavior;
    public bool isStopped;

    void Awake()
    {
        sdAttack = GetComponent<SDAttack>();
        sdHealth = GetComponent<SDHealth>();
        sdBehavior = GetComponent<SDBehavior>();
    }
    void OnEnable()
    {
        TimeManager.Instance.AddStoppable(this);

    }
    void OnDisable()
    {
        TimeManager.Instance.RemoveStoppable(this);
    }
    public void BackTo()
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        
    }
}
