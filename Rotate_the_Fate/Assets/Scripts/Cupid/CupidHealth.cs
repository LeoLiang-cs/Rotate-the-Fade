using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CupidHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isHitting = false;
    private Animator anim;
    public GameObject deathUIPanel;
    

    [Space]
    [Header("Status")]
    public int maxHealth = 10;
    public int currentHealth;   
    
    public int MushroomDamage = 3;
    public float knockbackForce = 10f; // 击退力的大小
    public float invulnerableTime = 0.5f;
    public bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isHitting)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            currentHealth -= MushroomDamage;
            if (currentHealth <= 0 )
            {
                isDead = true;
                Debug.Log("death");
                anim.SetTrigger("Death");
                deathUIPanel.SetActive(true);
            }
            isHitting = true;
            
            Vector3 knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.Normalize();
            
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Hit");
           
        }
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
}
