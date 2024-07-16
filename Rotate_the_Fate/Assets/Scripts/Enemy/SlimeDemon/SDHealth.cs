using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDHealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SDAttack sdAttack;
    Transform slimeCollision;
    Transform demonCollision;
    [Space]
    [Header("Status")]
    public bool isDemon = false;
    public bool isDead = false;
    public bool isHitting = false;
    public int demonHealth = 50;
    public int slimeHealth = 20;
    public int health;
    public int flameDamage = 1;
    public int frozenDamage = 4;
    public int lightningDamage = 3;
    public float frozenForce = 10f;
    public bool isTransforming = false;

    private DoubleBarDisplay health_bar;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sdAttack = GetComponent<SDAttack>();
        slimeCollision = transform.Find("SlimeCollision");
        demonCollision = transform.Find("DemonCollision");
        health_bar = GameObject.Find("BossBar").GetComponent<DoubleBarDisplay>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = slimeHealth;
        health_bar.Refill(health);
        isDemon = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isTransforming)
        {
            return;
        }
        Die();
    }

    public void TakeFrozenDamage(Vector2 attP)
    {
        if (isHitting)
            return;
        if (!isDemon)
        {
            health -= frozenDamage;
            health_bar.TakeDamage(frozenDamage);
            isHitting = true;
            //OnTakeFrozenDamage?.Invoke(attP);

            Vector2 dir = new Vector2(transform.position.x - attP.x, transform.position.y - attP.y).normalized;
            dir.y += 1;
            rb.AddForce(dir * frozenForce, ForceMode2D.Impulse);
            //spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF
            anim.SetTrigger("Hit");
            // if (!isSlowDown)
            // {
            //     GetComponent<TwinBehavior>().slowFactor = 0.5f;
            // }
        }
        else
        {
            health -= frozenDamage;
            health_bar.TakeDamage(frozenDamage);

            if (!sdAttack.isAttacking)
            {
                isHitting = true;
                anim.SetTrigger("Hit");
            }

        }

    }

    private void Die()
    {
        if (health <= 0 && !isDead && !isDemon)
        {
            Transform2Demon();

            // isHitting = false;
            // anim.SetTrigger("Die");
            // isDemon = true;
            // health = demonHealth;

            // anim.SetBool("IsDemon", true);

        }

        if (health <= 0 && !isDead && isDemon)
        {
            gameObject.layer = 2;
            isDead = true;
            anim.SetBool("Walk", false);
            anim.SetTrigger("Die");

        }
    }

    public void isHittingFalse()
    {
        isHitting = false;
    }

    public void Transform2Demon()
    {
        FindObjectOfType<AudioManager>().Play("DemonGrowl");
        isTransforming = true;
        Debug.Log("Transforming");
        anim.SetTrigger("Transform");

        isDemon = true;
        anim.SetBool("IsDemon", true);
        health = demonHealth;
        health_bar.Refill(health);
        GetComponent<SDBehavior>().currentSpeed = 400f;

        slimeCollision.gameObject.SetActive(false);
        demonCollision.gameObject.SetActive(true);
        //sdAttack.SetActive(true); // º§ªÓ sdAttack ∂‘œÛ

    }

    public void DestroyAfterAnim()
    {
        Destroy(gameObject);
    }


}
