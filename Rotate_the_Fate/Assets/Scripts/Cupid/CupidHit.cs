using UnityEngine;

public class CupidHit : MonoBehaviour
{
    public float knockbackForce = 10f; // 击退力的大小

    private void OnTriggerStay2D(Collider2D other)
    {
        // 检查碰撞到的物体的标签是否为 "enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            

            // 计算击退方向
            Vector3 knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.y = 0; // 确保击退只在水平面上（可选，根据需求调整）
            knockbackDirection.Normalize();

            // 应用击退力到自身
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 10, ForceMode2D.Impulse);
            Debug.Log("Here");
        }
    }
}
