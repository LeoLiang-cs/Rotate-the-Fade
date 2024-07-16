using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSystem
{
    public static float kYDistance = 1.5f;
    public static float kXDistance = 1f;
    public LayerMask enemyLayer;  // 敌人的图�?
    private GameObject mFrozenSample = null;
    private GameObject mFlameSample = null;
    private GameObject mLightningChainSample = null;
    private GameObject mTimeFreezeEffect = null;
    private GameObject flameEffect = null;
    private GameObject frozenEffect = null;
    public MagicSystem()
    {
        FrozenMagic.InitializedMagicSystem(this);
        mFrozenSample = Resources.Load<GameObject>("Prefabs/Frozen") as GameObject;
        mFlameSample = Resources.Load<GameObject>("Prefabs/Flame") as GameObject;
        mLightningChainSample = Resources.Load<GameObject>("Prefabs/Line") as GameObject;
        mTimeFreezeEffect = Resources.Load<GameObject>("Prefabs/TimeFreezeEffect") as GameObject;
        flameEffect = Resources.Load<GameObject>("Prefabs/CupidFlameEffect") as GameObject;
        frozenEffect = Resources.Load<GameObject>("Prefabs/CupidFrozenEffect") as GameObject;
    }

    public void FrozenSpawner(Vector3 p, bool torwardRight)
    {
        GameObject frozen = GameObject.Instantiate(mFrozenSample) as GameObject;
        GameObject effect = GameObject.Instantiate(frozenEffect) as GameObject;
        if(torwardRight)
        {
            frozen.transform.position = p ;
            frozen.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            frozen.transform.position = p ;
            frozen.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        effect.transform.position = p + Vector3.up * 0.4f;
    }

    public void LightningChainSpawner(Vector3 p)
    {
        GameObject lightning = GameObject.Instantiate(mLightningChainSample) as GameObject;
        lightning.GetComponent<LightningChainMagic>().TriggerLightningChain(p);  
    }


    public void FlameSpawner(Vector3 p, bool torwardRight)
    {
        GameObject flame = GameObject.Instantiate(mFlameSample) as GameObject;
        GameObject effect = GameObject.Instantiate(flameEffect) as GameObject;
        if(torwardRight)
        {
            flame.transform.position = p + Vector3.right * 0.5f + Vector3.up * 0.4f;
            flame.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            flame.transform.position = p + Vector3.left * 0.5f+ Vector3.up * 0.4f;
            flame.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        effect.transform.position = p + Vector3.up * 0.4f;
    }

    public void TimeFreezeSpawner(Timer timer, GameObject parent){
        GameObject time_freeze = GameObject.Instantiate(mTimeFreezeEffect) as GameObject;
        TimeEffect script = time_freeze.GetComponent<TimeEffect>();
        script.Set_up(timer, parent);
    }
}
