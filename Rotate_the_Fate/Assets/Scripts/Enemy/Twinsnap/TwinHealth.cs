using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class TwinHealth : MonoBehaviour
{


    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private Animator anim;
    private Timer slow_down_timer;
    private TwinAttackDetect attackDetect;
    private Rigidbody2D rb;
    public UnityEvent<Vector2> OnTakeFlameDamage;
    public UnityEvent<Vector2> OnTakeFrozenDamage;
    public UnityEvent<Vector2> OnTakeLighteningChainDamage;
    private float mFrozenTime = 5.0f;
    public float mFrozenTimeCount = 0.0f;
    public bool isSlowDown = false;
    public GameObject thankUI;

    // Health UI
    private BossHealthDisplay health_bar;

    [Space]
    [Header("Status")]
    public bool isDead = false;
    public bool isHitting = false;
    public int health = 10;
    public int flameDamage = 5;
    public int frozenDamage = 2;
    public int lightningDamage = 3;
    public int stabDamage = 1;

    private void Awake() {
        health_bar = GameObject.Find("BossBar").GetComponent<BossHealthDisplay>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mIceBlockSample = Resources.Load<GameObject>("Prefabs/MushFrozen") as GameObject;
        anim = GetComponent<Animator>();
        attackDetect = GetComponent<TwinAttackDetect>();

    }

    // Update is called once per frame
    void Update()
    {
        MeltFrozen();
        Die();
    }

    void FixedUpdate()
    {
        //StabCoolDown(); 
    }

    public void TakeFrozenDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        health -= frozenDamage;
        health_bar.TakeDamage(frozenDamage);
        isHitting = true;
        OnTakeFrozenDamage?.Invoke(attP);

        // Vector2 dir = new Vector2(transform.position.x - attP.x, transform.position.y - attP.y).normalized;
        // rb.AddForce(dir * frozenForce, ForceMode2D.Impulse);
        spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF
        anim.SetTrigger("Hit");
        if (!isSlowDown)
        {
            GetComponent<TwinBehavior>().slowFactor = 0.5f;
        }

        mFrozenTimeCount = mFrozenTime;
        isSlowDown = true;
    }

    public void TakeFlameDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        health -= flameDamage;
        health_bar.TakeDamage(flameDamage);
        OnTakeFlameDamage?.Invoke(attP);
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
        health_bar.TakeDamage(lightningDamage);
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
            thankUI.SetActive(true);
            gameObject.layer = 2;
            isDead = true;
            anim.SetBool("Walk", false);
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


    void StabHit()
    {

        anim.SetTrigger("Hit");
        health -= stabDamage;
        health_bar.TakeDamage(stabDamage);
        isHitting = true;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Stab"))
        {

            StabHit();

        }

    }
}
