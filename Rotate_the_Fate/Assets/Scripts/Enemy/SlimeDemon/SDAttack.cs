using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SDAttack : MonoBehaviour
{
    Collision coll;
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
    private CinemachineImpulseSource impulseSource;
    private SDTimeStop timeStop;
    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        chopTimer = gameObject.AddComponent<Timer>();
        punchTimer = gameObject.AddComponent<Timer>();
        timeStop = GetComponent<SDTimeStop>();

        chopTimer.Set_Timer(3.0f, 4f);
        punchTimer.Set_Timer(7.0f, 0f);

        chopTimer.action += Chop;
        punchTimer.action += Punch;

        TimeManager.Instance.AddTimer(chopTimer);
        TimeManager.Instance.AddTimer(punchTimer);

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
        if (sdHealth.isHitting || sdHealth.isDead || sdHealth.isTransforming || !sdHealth.isDemon || timeStop.isStopped)
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

    public void ChopGroundMusic()
    {
        FindObjectOfType<AudioManager>().Play("Sword");
    }

    public void PunchGroundShack()
    {
         if (impulseSource == null)
            {

                Debug.Log("impulseSource == null");
            }
            else
            {
                CameraShakeManager.instance.CameraShake(impulseSource);
            }
    }
}
