using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BoneHealth : MonoBehaviour
{
    public int mFrozenCount = 0;
    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private float mFrozenTime = 5.0f;
    private float mFrozenTimeCount = 0.0f;
    private Animator anim;
    private Timer slow_down_timer;
    private Rigidbody2D rb;
    private Timer frozen_timer;
    public UnityEvent<Vector2> OnTakeFlameDamage;
    public UnityEvent<Vector2> OnTakeFrozenDamage;
    public UnityEvent<Vector2> OnTakeLighteningChainDamage;

    [Space]
    [Header("Status")]
    public bool isDead = false;
    public bool isHitting = false;
    public int health = 10;
    public int flameDamage = 5;
    public int frozenDamage = 2;
    public int lightningDamage = 3;
    public int FlameForce = 5;
    public int frozenForce = 5;
    public int knockBackForce = 10;

    // quick fix of time magic on movement
    EnemyManger enemyManger;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mIceBlockSample = Resources.Load<GameObject>("Prefabs/BatFrozen") as GameObject;
        anim = GetComponent<Animator>();
        // need to fix later
        enemyManger = GetComponent<EnemyManger>();
    }

    // Update is called once per frame
    void Update()
    {
        // MeltFrozen();
        Die();
    }

    public void TakeFrozenDamage(Vector2 attP)
    {
        Debug.Log("Bat TakeFrozenDamage");
        if (isHitting)
            return;
        health -= frozenDamage;
        isHitting = true;
        OnTakeFrozenDamage?.Invoke(attP);
        if (mFrozenCount == 0)
        {
            Vector2 dir = new Vector2(transform.position.x - attP.x, transform.position.y - attP.y).normalized;
            rb.AddForce(dir * frozenForce, ForceMode2D.Impulse);
            spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF
            anim.SetTrigger("Hit");
            mFrozenCount++;
            Start_Slow_Down();
            // mFrozenTimeCount = mFrozenTime;
        }
        else if (mFrozenCount == 1)
        {
            Start_Frozen();
        }
        else
        {
            frozen_timer.Reset();
            slow_down_timer.Reset();
        }
    }

    public void TakeFlameDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        health -= flameDamage;
        OnTakeFlameDamage?.Invoke(attP);

        if (attP.x < transform.position.x)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0.1f) * FlameForce, ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0.1f) * FlameForce, ForceMode2D.Impulse);
        }
        spriteRenderer.color = Color.red;
        anim.SetTrigger("Hit");
        isHitting = true;
    }

    public void TakeLighteningChainDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        OnTakeLighteningChainDamage?.Invoke(attP);
        SetGravityOne();
        anim.SetTrigger("Hit");
        isHitting = true;
        health -= lightningDamage;
        spriteRenderer.color = Color.yellow;

        Vector3 knockBackDirection = transform.position - (Vector3)attP;
        knockBackDirection.Normalize();
        rb.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);
    }

    private void MeltFrozen()
    {
        if (mFrozenCount == 2)
        {
            if (mFrozenTimeCount <= 0)
            {
                isHitting = false;
                anim.speed = 1;
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
                //��iceBlock������
                foreach (Transform child in transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            mFrozenTimeCount -= Time.deltaTime;
        }
        else
        if (mFrozenCount == 1)
        {
            if (mFrozenTimeCount <= 0)
            {
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
            }
            mFrozenTimeCount -= Time.deltaTime;
        }
    }
    private void Start_Slow_Down()
    {
        enemyManger.Slow();
        if (slow_down_timer == null)
        {
            // Debug.Log("slow down");
            slow_down_timer = gameObject.AddComponent<Timer>();
            slow_down_timer.Set_Timer(mFrozenTime, 0f);
            slow_down_timer.onComplete += Cold_recovery;
            TimeManager.Instance.AddTimer(slow_down_timer);
        }
        else
        {
            // Debug.Log(slow_down_timer);
            slow_down_timer.Reset();
        }
    }

    private void Start_Frozen()
    {
        GameObject iceBlock = GameObject.Instantiate(mIceBlockSample) as GameObject;
        iceBlock.transform.localPosition = transform.position - Vector3.up * 0.5f;
        iceBlock.transform.parent = transform;
        anim.speed = 0;
        mFrozenCount++;
        // mFrozenTimeCount = mFrozenTime;
        enemyManger.Stop();
        if (frozen_timer == null)
        {
            frozen_timer = gameObject.AddComponent<Timer>();
            frozen_timer.Set_Timer(mFrozenTime, 0f);
            frozen_timer.onComplete += () => UnFreeze();
            TimeManager.Instance.AddTimer(frozen_timer);
        }
        else
        {
            frozen_timer.Reset();
        }
        slow_down_timer.Reset();

    }

    public void Cold_recovery()
    {
        spriteRenderer.color = Color.white;
        mFrozenCount = 0;
        enemyManger.BackTo();
    }

    public void UnFreeze()
    {
        anim.speed = 1;
        Cold_recovery();
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log("unfreeze");
        isHitting = false;
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

    public void isHittingFalse()
    {
        isHitting = false;
    }

    public void SetGravityZero()
    {
        rb.gravityScale = 0;
    }

    public void SetGravityOne()
    {
        rb.gravityScale = 10;
    }

}
