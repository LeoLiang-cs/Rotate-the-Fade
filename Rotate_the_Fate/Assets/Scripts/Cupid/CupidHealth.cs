using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CupidHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isHitting = false;
    private Animator anim;
    public GameObject deathUIPanel;
    public UnityEvent OnTakeDame;
    private HealthUI health_bar;


    [Space]
    [Header("Status")]
    public int maxHealth = 10;
    public int currentHealth;

    public int MushroomDamage = 3;
    public int SeedDamage = 1;
    public float knockBackForce = 10f;
    public bool invulnerable = false;
    public bool isDead = false;
    public GameObject handStoneSample;

    private CinemachineImpulseSource impulseSource;

    private void Awake() {
        health_bar = GameObject.Find("StateBar").GetComponent<HealthUI>();
    }
    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        handStoneSample = Resources.Load<GameObject>("Prefabs/HandStone") as GameObject;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (invulnerable)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Stab"))
        {
            FindObjectOfType<AudioManager>().Play("getHurt");
            if (impulseSource == null)
            {

                Debug.Log("impulseSource == null");
            }
            else
            {
                CameraShakeManager.instance.CameraShake(impulseSource);
            }
            
            Debug.Log("enter");
            currentHealth -= MushroomDamage;
            health_bar.TakeDamage(MushroomDamage);
            if (currentHealth <= 0 && !isDead)
            {
                isDead = true;
                Debug.Log("death");
                anim.SetTrigger("Death");
                deathUIPanel.SetActive(true);
            }
            isHitting = true;
            invulnerable = true;
            Vector3 knockBackDirection = transform.position - other.transform.position;
            knockBackDirection.Normalize();

            rb.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);
            anim.SetTrigger("Hit");

        }
    }

    public void TakeSeedDamage(Transform other)
    {

        currentHealth -= SeedDamage;
        health_bar.TakeDamage(SeedDamage);
        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("death");
            anim.SetTrigger("Death");
            //anim.SetBool("Die",true);
            deathUIPanel.SetActive(true);
        }
        isHitting = true;
        invulnerable = true;
        Vector3 knockBackDirection = transform.position - other.position;
        knockBackDirection.Normalize();

        rb.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);
        anim.SetTrigger("Hit");
    }

    public void DestroyAfterAnimation()
    {
        GameObject handStone = GameObject.Instantiate(handStoneSample) as GameObject;
        handStone.transform.position = transform.position + Vector3.up * 0.5f;
        Destroy(this.gameObject);
    }
}
