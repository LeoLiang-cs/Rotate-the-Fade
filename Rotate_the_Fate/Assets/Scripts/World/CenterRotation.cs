using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotation : MonoBehaviour
{
     public Transform cupidBehavior; // 目标对象
    public float rotationSpeed = 90f; // 旋转速度，角度/秒

    private bool isRotating = false;
    private Vector3 rotationCenter;
    private float targetAngle;
    private float currentAngle;

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = 90f; // 目标旋转角度为90度
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = -90f; // 目标旋转角度为-90度（逆时针）
        }

        if (isRotating)
        {
            // 每帧旋转一定角度
            float angleToRotate = rotationSpeed * Time.deltaTime;
            currentAngle += Mathf.Abs(angleToRotate);

            if (currentAngle >= Mathf.Abs(targetAngle))
            {
                angleToRotate = targetAngle - (currentAngle - Mathf.Abs(angleToRotate));
                isRotating = false; // 达到目标角度后停止旋转
            }

            // 以rotationCenter为中心旋转
            transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate);
        }
    }
}
