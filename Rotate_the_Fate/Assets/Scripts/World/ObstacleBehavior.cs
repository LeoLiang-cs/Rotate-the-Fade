using System.Collections;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public Vector3 undergroundPosition; // 刺的地下位置
    public Vector3 groundPosition;      // 刺的地表位置
    public float moveDuration = 5.0f;   // 移动到地表和回地下的时间

    void Start()
    {
        // 初始位置设置为地下位置
        transform.position = undergroundPosition;
        // 启动协程
        StartCoroutine(MoveStab());
    }

    IEnumerator MoveStab()
    {
        while (true)
        {
            // 移动到地表
            yield return StartCoroutine(MoveToPosition(groundPosition, moveDuration));
            // 停留在地表
            yield return new WaitForSeconds(5.0f);
            // 移动回地下
            yield return StartCoroutine(MoveToPosition(undergroundPosition, moveDuration));
            // 停留在地下
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
