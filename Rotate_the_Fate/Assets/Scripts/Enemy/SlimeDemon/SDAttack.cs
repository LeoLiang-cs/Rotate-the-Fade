using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SDAttack : MonoBehaviour
{
    Collision coll;
    SDDetect attackDetect;
    SDBehavior sdBehavior;
    Animator anim;
    SDHealth sdHealth;
    GameObject sd;
    Timer chopTimer;
    Timer punchTimer;
    Timer summonTimer;
    public bool isAttacking;
    public float skillCoolDown = 5f;
    public float skillCounter;
    public string lastSkill;
    private CinemachineImpulseSource impulseSource;
    private SDTimeStop timeStop;
    private GameObject boneSample;
    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        chopTimer = gameObject.AddComponent<Timer>();
        punchTimer = gameObject.AddComponent<Timer>();
        summonTimer = gameObject.AddComponent<Timer>();
        timeStop = GetComponent<SDTimeStop>();
        sdBehavior = GetComponent<SDBehavior>();

        chopTimer.Set_Timer(3.0f, 4f);
        punchTimer.Set_Timer(7.0f, 0f);
        summonTimer.Set_Timer(23.0f, 24.0f);

        chopTimer.action += Chop;
        punchTimer.action += Punch;
        summonTimer.action += Summon;

        TimeManager.Instance.AddTimer(chopTimer);
        TimeManager.Instance.AddTimer(punchTimer);
        TimeManager.Instance.AddTimer(summonTimer);

        sd = GameObject.Find("SlimeDemon");
        coll = sd.GetComponent<Collision>();
        anim = sd.GetComponent<Animator>();
        attackDetect = GetComponent<SDDetect>();
        sdHealth = sd.GetComponent<SDHealth>();
        boneSample = Resources.Load<GameObject>("Prefabs/Bone") as GameObject;
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
        TriggerSummon();
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

    void Summon()
    {
        anim.SetTrigger("Att4");
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

    public void  TriggerSummon()
    {
        if (attackDetect.detectCupid && !isAttacking)
        {
           summonTimer.Trigger();
        }
    }

    public void PunchGroundMusic()
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

    public void BoneSpawn()
    {
        GameObject bone = GameObject.Instantiate(boneSample) as GameObject;
        bone.transform.position = transform.position + sdBehavior.faceDire * 0.5f + Vector3.up * 1.5f;

    }
}
