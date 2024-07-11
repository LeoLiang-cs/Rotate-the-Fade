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
    private CupidCollision coll;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        mMagicSystem = new MagicSystem();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        currentMagic.Add(MagicType.Frozen);
        currentMagic.Add(MagicType.LightingChain);
        currentMagic.Add(MagicType.Flame);
        coll = GetComponent<CupidCollision>();
        Add_Magic(MagicType.Time);
        
    }

    // Update is called once per frame
    void Update()
    {
        MagicAttack();
        SwitchMagic();
    }

    public void MagicAttack() {
        if(Input.GetKeyDown(KeyCode.J) && !isAttacking && coll.onGround)
        {
            isAttacking = true;
            rb.velocity = new Vector2(0, 0);
            switch(currentMagic[chooseMagic])
            {
                case MagicType.Frozen:
                    mMagicSystem.FrozenSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    break;
                case MagicType.LightingChain:
                    mMagicSystem.LightningChainSpawner(transform.position);
                    break;
                case MagicType.Flame:
                    mMagicSystem.FlameSpawner(transform.position, GetComponent<CupidBehavior>().mTowardRight);
                    break;
                case MagicType.Time:
                    timers.Trigger();
                    isAttacking = false;
                    break;
            }
        }
    }
    public void Add_Magic(MagicType type){
        currentMagic.Add(MagicType.Time);
        Timer script = gameObject.AddComponent<Timer>();
        timers = script;
        script.Set_Timer(CoolDownTime.TimeMagic, CoolDownTime.TimeMagic + 1f);
        script.action += () => mMagicSystem.TimeFreezeSpawner(script, gameObject);
    }
    public void SwitchMagic() {
        if(Input.GetKeyDown(KeyCode.H))
        {
            chooseMagic++;
            chooseMagic = chooseMagic%currentMagic.Count;
        }
       
    }

}
