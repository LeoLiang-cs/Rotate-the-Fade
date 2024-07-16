using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDAttack : MonoBehaviour
{
    SDDetect attackDetect;
    Animator anim;
    SDHealth sdHealth;
    GameObject sd;
    Timer chopTimer;
    Timer punchTimer;
    public bool isAttacking;
    public float skillCoolDown = 5f;
    public float skillCounter;
    public string lastSkill;
    void Awake()
    {
        chopTimer = gameObject.AddComponent<Timer>();
        punchTimer = gameObject.AddComponent<Timer>();

        chopTimer.Set_Timer(3.0f, 4f);
        punchTimer.Set_Timer(7.0f, 0f);

        chopTimer.action += Chop;
        punchTimer.action += Punch;
        anim = GetComponent<Animator>();
        attackDetect = GetComponent<SDDetect>();
        sdHealth = GetComponent<SDHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        skillCounter = skillCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (sdHealth.isHitting || sdHealth.isDead || sdHealth.isTransforming || !sdHealth.isDemon)
        {
            return;
        }

        TriggerChop();
        TriggerPunch();
    }

    void Chop()
    {
        Debug.Log("Attacking");
        anim.SetTrigger("Att1");
        isAttacking = true;

    }

    void Punch()
    {
        Debug.Log("Attacking");
        anim.SetTrigger("Att2");

        isAttacking = true;
    }



    public void EndAttack()
    {
        isAttacking = false;
    }

    public void TriggerChop()
    {
        if (attackDetect.detectCupid && !isAttacking)
        {
            chopTimer.Trigger();
        }
    }

    public void TriggerPunch()
    {
        if (attackDetect.detectCupid && !isAttacking)
        {
            punchTimer.Trigger();
        }
    }

    public void punchGroundMusic()
    {
        FindObjectOfType<AudioManager>().Play("SDAttack");
    }
}
