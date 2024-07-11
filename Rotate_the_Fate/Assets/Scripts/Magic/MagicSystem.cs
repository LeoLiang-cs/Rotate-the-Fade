using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSystem
{
    public static float kYDistance = 1.5f;
    public static float kXDistance = 1f;
    public LayerMask enemyLayer;  // 敌人的图层
    private GameObject mFrozenSample = null;
    private GameObject mFlameSample = null;
    private GameObject mLightningChainSample = null;
    public MagicSystem()
    {
        FrozenMagic.InitializedMagicSystem(this);
        mFrozenSample = Resources.Load<GameObject>("Prefabs/Frozen") as GameObject;
        mFlameSample = Resources.Load<GameObject>("Prefabs/Flame") as GameObject;
        mLightningChainSample = Resources.Load<GameObject>("Prefabs/LightningChain") as GameObject;
    }

    public void FrozenSpawner(Vector3 p, bool torwardRight)
    {
        GameObject frozen = GameObject.Instantiate(mFrozenSample) as GameObject;

        if(torwardRight)
        {
            frozen.transform.position = p + Vector3.right*kYDistance + Vector3.up*kXDistance;
            frozen.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            frozen.transform.position = p + Vector3.left*kYDistance + Vector3.up*kXDistance;
            frozen.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
            
    }

    public void LightningChainSpawner(Vector3 p)
    {
        GameObject lightning = GameObject.Instantiate(mLightningChainSample) as GameObject;
        lightning.GetComponent<LightningChainMagic>().TriggerLightningChain(p);  
    }


    public void FlameSpawner(Vector3 p, bool torwardRight)
    {
        GameObject flame = GameObject.Instantiate(mFlameSample) as GameObject;

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
            
    }
}
