using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TwinHealth : MonoBehaviour
{


    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private Animator anim;
    private Timer slow_down_timer;
    private Rigidbody2D rb;
    public UnityEvent<Vector2> OnTakeFlameDamage;
    public UnityEvent<Vector2> OnTakeFrozenDamage;
    public UnityEvent<Vector2> OnTakeLighteningChainDamage;
    private float mFrozenTime = 5.0f;
    private float mFrozenTimeCount = 0.0f;
    private bool isSlowDown = false;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    public void TakeFrozenDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        health -= frozenDamage;
        isHitting = true;
        OnTakeFrozenDamage?.Invoke(attP);

        Vector2 dir = new Vector2(transform.position.x - attP.x, transform.position.y - attP.y).normalized;
        rb.AddForce(dir * frozenForce, ForceMode2D.Impulse);
        spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF
        anim.SetTrigger("Hit");
        GetComponent<TwinBehavior>().slowFactor = 0.5f;
        mFrozenTimeCount = mFrozenTime;
        isSlowDown = true;


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
        Debug.Log("Flame");
        spriteRenderer.color = Color.red;
        anim.SetTrigger("Hit");
        isHitting = true;
    }

    public void TakeLighteningChainDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        OnTakeLighteningChainDamage?.Invoke(attP);
        health -= lightningDamage;
        spriteRenderer.color = Color.yellow;
    }


    private void MeltFrozen()
    {
        
        if (isSlowDown)
        {
            if (mFrozenTimeCount <= 0)
            {
                spriteRenderer.color = Color.white;
                isSlowDown = false;
            }
            mFrozenTimeCount -= Time.deltaTime;
        }
    }
    private void Die()
    {
        if (health <= 0 && !isDead)
        {
            gameObject.layer = 2;
            isDead = true;
            anim.SetTrigger("Die");
            GetComponent<RotationBehavior>().enabled = false;
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
}
