using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public List<MagicType> currentMagic;
    private Timer timers;
    public int chooseMagic = 0;
    private MagicSystem mMagicSystem = null;
    public static bool isAttacking = false;
    private Collision coll;

    private Rigidbody2D rb;
    private CupidHealth cupidHealth;
    public float magicEnergy = 10;
    public float currentMagicCost;
    public float frozenCost = 1;
    public float flameCost = 3;
    public float lightingCost = 2;
    public float timeCost = 5;
    private TripleBarDisplay energy_bar;
    private AbilityDisplay abilityDisplay;
    // Start is called before the first frame update
    void Awake()
    {
        mMagicSystem = new MagicSystem();
        rb = GetComponent<Rigidbody2D>();
        cupidHealth = GetComponent<CupidHealth>();
        energy_bar = GameObject.Find("StateBar").GetComponent<TripleBarDisplay>();
        //health_bar = GameObject.Find("StateBar").GetComponent<HealthUI>();
        //abilityDisplay = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
        chooseMagic = AbilityStats.instance.chooseMagic;
    }
    void Start()
    {
        //currentMagic = abilityDisplay.gianed_magics;
        //currentMagic.Add(MagicType.Frozen);
        //currentMagic.Add(MagicType.LightingChain);
        //currentMagic.Add(MagicType.Flame);
        coll = GetComponent<Collision>();

        //Add_Magic(MagicType.Time);

    }

    // Update is called once per frame
    void Update()
    {
        MagicAttack();
        SwitchMagic();
    }

    void FixedUpdate()
    {
        EnergyRecover();
    }
    public void MagicAttack()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking && coll.onGround && currentMagic.Count > 0 && magicEnergy >= currentMagicCost)
        {
            isAttacking = true;
            rb.velocity = new Vector2(0, 0);
            switch (currentMagic[chooseMagic])
            {
                case MagicType.Frozen:
                    magicEnergy -= frozenCost;
                    energy_bar.ValueDecrease(frozenCost);
                    mMagicSystem.FrozenSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    FindObjectOfType<AudioManager>().Play("Freeze");
                    break;
                case MagicType.LightingChain:
                    magicEnergy -= lightingCost;
                    energy_bar.ValueDecrease(lightingCost);
                    mMagicSystem.LightningChainSpawner(transform.position);
                    FindObjectOfType<AudioManager>().Play("Lightening");
                    break;
                case MagicType.Flame:
                    magicEnergy -= flameCost;
                    energy_bar.ValueDecrease(flameCost);
                    mMagicSystem.FlameSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    FindObjectOfType<AudioManager>().Play("Fire");
                    break;
                case MagicType.Time:
                    magicEnergy -= timeCost;
                    energy_bar.ValueDecrease(timeCost);
                    timers.Trigger();
                    isAttacking = false;
                    break;
            }
        }
    }
    public void Add_Magic(MagicType type)
    {
        Debug.Log("add Timer");
        currentMagic.Add(MagicType.Time);
        Timer script = gameObject.AddComponent<Timer>();
        timers = script;
        script.Set_Timer(CoolDownTime.TimeMagic, CoolDownTime.TimeMagic + 1f);
        script.action += () => mMagicSystem.TimeFreezeSpawner(script, gameObject);
        TimeManager.Instance.AddTimer(timers);
    }
    public void SwitchMagic()
    {
        if (Input.GetKeyDown(KeyCode.H) && currentMagic.Count > 0)
        {
            chooseMagic++;
            chooseMagic = chooseMagic % currentMagic.Count;
            AbilityStats.instance.chooseMagic = chooseMagic;
            switch (currentMagic[chooseMagic])
            {
                case MagicType.Frozen:
                    currentMagicCost = frozenCost;
                    break;
                case MagicType.LightingChain:
                    currentMagicCost = lightingCost;
                    break;
                case MagicType.Flame:
                    currentMagicCost = flameCost;
                    break;
                case MagicType.Time:
                    currentMagicCost = timeCost;
                    // timers.Trigger();
                    isAttacking = false;
                    break;
            // health_bar.Set_Cost(magicDamge);
            }
            energy_bar.Set_Cost(currentMagicCost);
        }

    }

    private void EnergyRecover(){
        if(magicEnergy < 10){
            magicEnergy += 0.01f;
            energy_bar.ValueIncrease(0.01f);
        }
    }

}
