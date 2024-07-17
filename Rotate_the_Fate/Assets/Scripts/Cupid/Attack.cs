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
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private CupidHealth cupidHealth;
    public float magicEnergy = 10;
    public float currentMagicCost;
    public float frozenCost = 1;
    public float flameCost = 3;
    public float lightingCost = 2;
    public float timeCost = 5;
    public float LightningRadius = 5;
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
        abilityDisplay = GameObject.Find("Ability").GetComponent<AbilityDisplay>();
        chooseMagic = AbilityStats.instance.chooseMagic;
    }
    void Start()
    {
        currentMagic = abilityDisplay.gianed_magics;
        // currentMagic.Add(MagicType.Frozen);
        currentMagic.Add(MagicType.LightingChain);
        // currentMagic.Add(MagicType.Flame);
          Add_Magic(MagicType.Time);
        coll = GetComponent<Collision>();
        GameObject a = GameObject.Find("FrozenVase");
        GameObject a2 = GameObject.Find("AirWall1");
        GameObject b = GameObject.Find("Brazier");
        GameObject c = GameObject.Find("FlashBottle");
        GameObject d = GameObject.Find("SandClock");
        if (a != null && currentMagic.Count >= 1)
        {
            Destroy(a);
            Destroy(a2);
        }
        if (b != null && currentMagic.Count >= 2)
        {
            Destroy(b);
        }
        if (c != null && currentMagic.Count >= 3)
        {
            Destroy(c);
        }
        if (d != null && currentMagic.Count >= 4)
        {
            Destroy(d);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isAttacking: " + isAttacking);
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


            rb.velocity = new Vector2(0, 0);
            switch (currentMagic[chooseMagic])
            {
                case MagicType.Frozen:
                    isAttacking = true;
                    magicEnergy -= frozenCost;
                    energy_bar.ValueDecrease(frozenCost);
                    mMagicSystem.FrozenSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    FindObjectOfType<AudioManager>().Play("Freeze");
                    break;
                case MagicType.LightingChain:
                    magicEnergy -= lightingCost;
                    energy_bar.ValueDecrease(lightingCost);
                    Collider2D[] hitEnemies = LightningDetectEnemy();
                    mMagicSystem.LightningChainSpawner(transform.position, hitEnemies);
                    if (hitEnemies.Length > 0)
                    {
                        FindObjectOfType<AudioManager>().Play("Lightening");
                    }
                    //FindObjectOfType<AudioManager>().Play("Lightening");
                    break;
                case MagicType.Flame:
                    isAttacking = true;
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

    private void EnergyRecover()
    {
        if (magicEnergy < 10)
        {
            magicEnergy += 0.01f;
            energy_bar.ValueIncrease(0.01f);
        }
    }

    private Collider2D[] LightningDetectEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, LightningRadius, enemyLayer);
        //Debug.Log("enemies num: " + hitEnemies.Length);
        return hitEnemies;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LightningRadius);
    }

}
