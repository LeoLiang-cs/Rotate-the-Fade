using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : MonoBehaviour
{
    public int mFrozenCount = 0;
    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private float mFrozenTime = 5.0f;
    private float mFrozenTimeCount = 0.0f;
    private Animator anim;
    private Timer slow_down_timer;
    private Timer frozen_timer;

    [Space]
    [Header("Status")]
    public bool isDead = false;
    public bool isHitting = false;
    public int health = 10;
    public int flameDamage = 5;
    public int frozenDamage = 2;
    public int lightningDamage = 3;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mIceBlockSample = Resources.Load<GameObject>("Prefabs/MushFrozen") as GameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // MeltFrozen();
        Die();
    }

    public void TakeFrozenDamage(Vector2 attP) {
        if (isHitting)
            return;
        health -= frozenDamage;
        isHitting = true;
        if (mFrozenCount == 0) {
            if(attP.x < transform.position.x) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * 5, ForceMode2D.Impulse);
            } else {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * 5, ForceMode2D.Impulse);
            }
            spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF
            anim.SetTrigger("Hit");
            mFrozenCount++;
            Start_Slow_Down();
            // mFrozenTimeCount = mFrozenTime;
        }else if(mFrozenCount == 1) {
            Start_Frozen();
        }else{
            frozen_timer.Reset();
            slow_down_timer.Reset();
        }
    }

    public void TakeFlameDamage(Vector2 attP) {
        if (isHitting)
            return;
        health -= flameDamage;
        if (attP.x < transform.position.x) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 10, ForceMode2D.Impulse);
        } else {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * 10, ForceMode2D.Impulse);
        }
        spriteRenderer.color = Color.red; 
        anim.SetTrigger("Hit");
        isHitting = true;
    }    

    public void TakeLighteningChainDamage() {
        health -= lightningDamage;
        spriteRenderer.color = Color.yellow; 
    }    

    private void MeltFrozen() {
        if(mFrozenCount == 2) {
            if(mFrozenTimeCount <= 0) {
                isHitting = false;  
                anim.speed = 1;
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
                //把iceBlock给销毁
                foreach(Transform child in transform) {
                    GameObject.Destroy(child.gameObject);
                }
            }
            mFrozenTimeCount -= Time.deltaTime;
        } else
        if(mFrozenCount == 1) {
            if(mFrozenTimeCount <= 0) {
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
            }
            mFrozenTimeCount -= Time.deltaTime;
        }
    }
    private void Start_Slow_Down(){
        if(slow_down_timer == null){
            // Debug.Log("slow down");
            slow_down_timer = gameObject.AddComponent<Timer>();
            slow_down_timer.Set_Timer(mFrozenTime, 0f);
            slow_down_timer.onComplete += Cold_recovery;
            TimeManager.Instance.AddTimer(slow_down_timer);
        }else{
            // Debug.Log(slow_down_timer);
            slow_down_timer.Reset();
        }
    }

    private void Start_Frozen(){
        GameObject iceBlock = GameObject.Instantiate(mIceBlockSample) as GameObject;
        iceBlock.transform.localPosition = transform.position;
        iceBlock.transform.parent = transform;
        anim.speed = 0;
        mFrozenCount++;
        // mFrozenTimeCount = mFrozenTime;
        if(frozen_timer == null){
            frozen_timer = gameObject.AddComponent<Timer>();
            frozen_timer.Set_Timer(mFrozenTime, 0f);
            frozen_timer.onComplete += () => UnFreeze();
            TimeManager.Instance.AddTimer(frozen_timer);
        }else{
            frozen_timer.Reset();
        }
        slow_down_timer.Reset();
    }

    public void Cold_recovery(){
        spriteRenderer.color = Color.white;
        mFrozenCount = 0;
    }
    
    public void UnFreeze(){
        anim.speed = 1;
        Cold_recovery();
        //把iceBlock给销毁
        foreach(Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log("unfreeze");
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
