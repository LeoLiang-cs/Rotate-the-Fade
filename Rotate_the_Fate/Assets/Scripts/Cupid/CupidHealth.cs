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
    

    [Space]
    [Header("Status")]
    public int maxHealth = 10;
    public int currentHealth;   
    
    public int MushroomDamage = 3;
    public float knockbackForce = 10f; 
    public bool invulnerable = false;
    public bool isDead = false;
    public GameObject handStoneSample;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        handStoneSample = Resources.Load<GameObject>("Prefabs/HandStone") as GameObject;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (invulnerable)
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
            invulnerable = true;
            Vector3 knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.Normalize();
            
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Hit");
           
        }
    }

    public void DestroyAfterAnimation()
    {
        GameObject handStone = GameObject.Instantiate(handStoneSample) as GameObject;
        handStone.transform.position = transform.position+Vector3.up*0.5f;
        Destroy(this.gameObject);
    }
}
