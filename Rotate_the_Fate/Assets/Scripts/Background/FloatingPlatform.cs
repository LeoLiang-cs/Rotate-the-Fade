using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float speed = 2f; // 平移速度
    public float distance = 5f; // 平移距离

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // 平移平台
        if (movingRight)
        {
            transform.localPosition += Vector3.right * speed * Time.deltaTime;
            if (transform.localPosition.x >= startPos.x + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.localPosition += Vector3.left * speed * Time.deltaTime;
            if (transform.localPosition.x <= startPos.x - distance)
            {
                movingRight = true;
            }
        }
    }
}

