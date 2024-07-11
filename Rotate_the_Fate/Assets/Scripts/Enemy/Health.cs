using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator anim;
    private bool isDead = false;
    [Space]
    [Header("Status")]
    public int health = 10;
    public int flameDamage = 5;
    public int frozenDamage = 2;
    public int lightningDamage = 3;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(PlayDeathAnimationAndDestroy());
        }
    }

    private IEnumerator PlayDeathAnimationAndDestroy()
    {
        anim.SetTrigger("Die");

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        Destroy(gameObject);
    }

    public void FrozenDamage()
    {
        health -= frozenDamage;
    }

    public void LightningDamage()
    {
        health -= lightningDamage;
    }

    public void FlameDamage()
    {
        health -= flameDamage;
    }

   
}
