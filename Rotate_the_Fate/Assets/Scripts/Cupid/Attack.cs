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
    public int magicEnergy = 10;
    public int currentMagicCost;
    public int frozenCost = 1;
    public int flameCost = 2;
    public int lightingCost = 1;
    public int timeCost = 5;
    private HealthUI health_bar;
    private AbilityDisplay abilityDisplay;
    // Start is called before the first frame update
    void Awake()
    {
        mMagicSystem = new MagicSystem();
        rb = GetComponent<Rigidbody2D>();
        cupidHealth = GetComponent<CupidHealth>();
        //health_bar = GameObject.Find("StateBar").GetComponent<HealthUI>();
        //abilityDisplay = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
        chooseMagic = AbilityStats.instance.chooseMagic;
    }
    void Start()
    {
        //currentMagic = abilityDisplay.gianed_magics;
        currentMagic.Add(MagicType.Frozen);
        // currentMagic.Add(MagicType.LightingChain);
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

    public void MagicAttack()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking && coll.onGround && currentMagic.Count > 0 )
        {
            isAttacking = true;
            rb.velocity = new Vector2(0, 0);
            switch (currentMagic[chooseMagic])
            {
                case MagicType.Frozen:
                    magicEnergy -= frozenCost;
                    mMagicSystem.FrozenSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    break;
                case MagicType.LightingChain:
                    magicEnergy -= lightingCost;
                    mMagicSystem.LightningChainSpawner(transform.position);
                    break;
                case MagicType.Flame:
                    magicEnergy -= flameCost;
                    mMagicSystem.FlameSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    break;
                case MagicType.Time:
                    magicEnergy -= timeCost;
                    timers.Trigger();
                    isAttacking = false;
                    break;
            }
        }
    }
    public void Add_Magic(MagicType type)
    {
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
            // health_bar.Set_Cost(magicDamge);
        }

    }

}
