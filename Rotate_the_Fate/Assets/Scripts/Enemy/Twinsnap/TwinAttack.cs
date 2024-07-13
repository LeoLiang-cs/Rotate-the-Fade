using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinAttack : MonoBehaviour
{
    Collision coll;
    TwinAttackDetect attackDetect;
    Animator anim;
    GameObject seedSample;
    TwinHealth twinHealth;
    public bool isAttacking;
    public float skillCoolDown = 5f;
    public float skillCounter;
    public string lastSkill;
    public bool isShotting;
    public bool isSprinting;
    public float sprintSpeed = 400f;

    void Awake()
    {
        coll = GetComponent<Collision>();
        anim = GetComponent<Animator>();
        attackDetect = GetComponent<TwinAttackDetect>();
        seedSample = Resources.Load<GameObject>("Prefabs/Seed");
        twinHealth = GetComponent<TwinHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        skillCounter = skillCoolDown;
        lastSkill = "Shot";

    }

    // Update is called once per frame
    void Update()
    {
        if(twinHealth.isHitting || twinHealth.isDead)
        {
            return;
        }

        Bite();
        Shot();
        Sprint();
    }

    void Bite()
    {
        if (attackDetect.detectCupid && coll.onGround && !isShotting && !isSprinting)
        {
            anim.SetTrigger("Bite");
            isAttacking = true;
        }
    }

    void Shot()
    {
        skillCounter -= Time.deltaTime;
        if (skillCounter <= 0 && lastSkill == "Sprint" && !isSprinting)
        {
            Debug.Log("Shot");
            lastSkill = "Shot";
            skillCounter = skillCoolDown;
            anim.SetTrigger("Shot");
            isShotting = true;

            SeedSpawn();
        }

    }

    void Sprint()
    {
        skillCounter -= Time.deltaTime;
        if (skillCounter <= 0 && lastSkill == "Shot")
        {
            Debug.Log("Sprint");
            lastSkill = "Sprint";
            anim.SetTrigger("Sprint");
            isSprinting = true;
            GetComponent<TwinBehavior>().currentSpeed = sprintSpeed;
        }
    }

    void SeedSpawn()
    {
        GameObject seed = GameObject.Instantiate(seedSample) as GameObject;
        seed.transform.position = transform.position + GetComponent<TwinBehavior>().faceDire * 2 + Vector3.up;
        seed.transform.localScale = transform.localScale;
    }

    public void EndSprint()
    {
        GetComponent<TwinBehavior>().currentSpeed = 200f;
        skillCounter = skillCoolDown;
        isSprinting = false;
    }

}
