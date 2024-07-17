using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SDTimeStop : MonoBehaviour, IStoppable
{
    private SDAttack sdAttack;
    private SDHealth sdHealth;
    private SDBehavior sdBehavior;
    private Animator anim;
    private Rigidbody2D rb;
    public bool isStopped;

    void Awake()
    {
        sdAttack = GetComponent<SDAttack>();
        sdHealth = GetComponent<SDHealth>();
        sdBehavior = GetComponent<SDBehavior>();
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
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
        isStopped = false;
        anim.speed = 1;
    }

    public void Stop()
    {
        isStopped = true;
        anim.speed = 0;
        rb.velocity = Vector2.zero;
    }
}
