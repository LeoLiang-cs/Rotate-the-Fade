using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private float mFrozenTime = 2.0f;
    private float mFrozenTimeCount = 0.0f;
    private Animator anim;

    [Space]
    [Header("Status")]
    public int mFrozenCount = 0;
    public bool isDead = false;
    public bool isHitting = false;
    public int health = 10;
    public int flameDamage = 5;
    public int frozenDamage = 2;
    public int lightningDamage = 3;


    // Start is called before the first frame update
    void Start()
    {
        mIceBlockSample = Resources.Load<GameObject>("Prefabs/BushFrozen") as GameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MeltFrozen();
        Die();
    }

    public void TakeFrozenDamage(Vector2 attP)
    {
        Debug.Log("Bush frozen");
        if (isHitting)
            return;
        health -= frozenDamage;
        isHitting = true;

        GameObject iceBlock = GameObject.Instantiate(mIceBlockSample) as GameObject;
        iceBlock.transform.localPosition = transform.position;
        iceBlock.transform.parent = transform;

        anim.speed = 0;
        mFrozenCount++;
        mFrozenTimeCount = mFrozenTime;
    }

    public void TakeFlameDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        health -= flameDamage;

        spriteRenderer.color = Color.red;
        anim.SetTrigger("Hit");
        isHitting = true;
    }

    public void TakeLighteningChainDamage()
    {
        health -= lightningDamage;
        spriteRenderer.color = Color.yellow;
    }

    private void MeltFrozen()
    {

        if (mFrozenCount == 1 && mFrozenTimeCount <= 0)
        {
            isHitting = false;
            anim.speed = 1;
            spriteRenderer.color = Color.white;
            mFrozenCount = 0;
            //°ÑiceBlock¸øÏú»Ù
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "BushFrozen(Clone)")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
        }
        mFrozenTimeCount -= Time.deltaTime;
    }

    private void Die()
    {
        if (health <= 0 && !isDead)
        {
            gameObject.layer = 2;
            isDead = true;
            anim.SetTrigger("Die");
        }
    }

    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }


}
