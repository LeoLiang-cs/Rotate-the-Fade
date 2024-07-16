using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDAttack : MonoBehaviour
{
    Collision coll;
    SDDetect attackDetect;
    Animator anim;
    SDHealth sdHealth;
    GameObject sd;
    public bool isAttacking;
    public float skillCoolDown = 5f;
    public float skillCounter;
    public string lastSkill;
    void Awake()
    {
        sd = GameObject.Find("SlimeDemon");
        coll = sd.GetComponent<Collision>();
        anim = sd.GetComponent<Animator>();
        attackDetect = GetComponent<SDDetect>();
        sdHealth = sd.GetComponent<SDHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        skillCounter = skillCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(sdHealth.isHitting || sdHealth.isDead || sdHealth.isTransforming || !sdHealth.isDemon)
        {
            return;
        }
        Chop();
    }

    void Chop()
    {
         if (attackDetect.detectCupid && !isAttacking)
        {
            Debug.Log("Attacking");
            anim.SetTrigger("Att1");
            isAttacking = true;
        }
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
