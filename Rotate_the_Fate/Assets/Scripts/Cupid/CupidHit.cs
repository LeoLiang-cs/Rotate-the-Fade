using System.Collections;
using UnityEngine;

public class CupidHit : MonoBehaviour
{
    public float knockbackForce = 10f; // 击退力的大小
    public float invulnerableTime = 0.5f;
    private Rigidbody2D rb;
    public static bool isHitting = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHitting)
            return;

        // 检查碰撞到的物体的标签是否为 "enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            isHitting = true;
            
            Vector3 knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.Normalize();
            
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            StartCoroutine(HitTimeCoroutine(invulnerableTime));
        }
    }

   

    private IEnumerator HitTimeCoroutine(float duration)
    { 
        yield return new WaitForSecondsRealtime(duration);
        isHitting = false;
    }


}
