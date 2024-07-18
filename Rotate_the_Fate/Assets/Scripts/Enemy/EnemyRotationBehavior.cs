using UnityEngine;

public class EnemyRotationBehavior : MonoBehaviour
{
    private bool previousIsRotatingState = false;

    // Start is called before the first frame update
    void Start()
    {
        previousIsRotatingState = WorldRotation.isRotating;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
    }

    void CheckRotation()
    {
        if (!previousIsRotatingState && WorldRotation.isRotating)
        {
            // WorldRotation.isRotating 从 false 变为 true 时执行一次
            PerformRotation();
        }

        // 更新之前的状态
        previousIsRotatingState = WorldRotation.isRotating;
    }

    void PerformRotation()
    {
        if (WorldRotation.isClockwise)
        {
            transform.Rotate(0, 0, -90);
        }
        else
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
