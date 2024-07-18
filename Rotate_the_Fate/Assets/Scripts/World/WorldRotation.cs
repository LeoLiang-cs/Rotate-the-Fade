using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldRotation : MonoBehaviour
{
    public static bool isRotating = false;
    public float rotationSpeed = 40f;
    private Quaternion targetRotation;

    //New CenterRotation
    public Transform cupidBehavior; // 目标对象
    private Vector3 rotationCenter;
    private float targetAngle;
    private float currentAngle;
    private bool isClockwise;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        SceneReset();
    }

    // void Rotation() 
    // {
    //      if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
    //     {
    //         isRotating = true;
    //         targetRotation = Quaternion.Euler(0, 0, 90) * transform.rotation;
    //     }

    //     if (Input.GetKeyDown(KeyCode.E) && !isRotating)
    //     {
    //         isRotating = true;
    //         targetRotation = Quaternion.Euler(0, 0, -90) * transform.rotation;
    //     }

    //     if (isRotating)
    //     {
    //         transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    //         if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
    //         {
    //             transform.rotation = targetRotation;
    //             isRotating = false;
    //         }

    //     }
    // }



    // void Rotation()
    // {
    //     if (Input.GetKeyDown(KeyCode.Q) && !isRotating && cupidBehavior.GetComponent<Collision>().onGround)
    //     {
    //         FindObjectOfType<AudioManager>().Play("Rotate");
    //         isRotating = true;
    //         rotationCenter = cupidBehavior.transform.position;
    //         currentAngle = 0f;
    //         targetAngle = 90f; // 目标旋转角度为90度
    //         isClockwise = true;
    //     }

    //     if (Input.GetKeyDown(KeyCode.E) && !isRotating && cupidBehavior.GetComponent<Collision>().onGround)
    //     {
    //         FindObjectOfType<AudioManager>().Play("Rotate");
    //         isRotating = true;
    //         rotationCenter = cupidBehavior.transform.position;
    //         currentAngle = 0f;
    //         targetAngle = -90f; // 目标旋转角度为-90度（逆时针）
    //         isClockwise = false;
    //     }

    //     if (isRotating)
    //     {
    //         // 每帧旋转一定角度
    //         float angleToRotate = rotationSpeed * Time.deltaTime;
    //         if (!isClockwise)
    //             angleToRotate = -angleToRotate;

    //         currentAngle += angleToRotate;

    //         if (Mathf.Abs(currentAngle) >= Mathf.Abs(targetAngle))
    //         {
    //             angleToRotate = targetAngle - (currentAngle - angleToRotate);
    //             isRotating = false; // 达到目标角度后停止旋转
    //         }

    //         // 以rotationCenter为中心旋转
    //         transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate);

    //     }
    // }

        void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            FindObjectOfType<AudioManager>().Play("Rotate");
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = 90f; // 目标旋转角度为90度
            isClockwise = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            FindObjectOfType<AudioManager>().Play("Rotate");
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = -90f; // 目标旋转角度为-90度（逆时针）
            isClockwise = false;
        }

        if (isRotating)
        {
            // 每帧旋转一定角度
            float angleToRotate = rotationSpeed * Time.deltaTime;
            if (!isClockwise)
                angleToRotate = -angleToRotate;

            currentAngle += angleToRotate;

            if (Mathf.Abs(currentAngle) >= Mathf.Abs(targetAngle))
            {
                angleToRotate = targetAngle - (currentAngle - angleToRotate);
                isRotating = false; // 达到目标角度后停止旋转
            }

            // 以rotationCenter为中心旋转
            transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate);

        }
    }



    void SceneReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            // 閲嶆柊鍔犺浇褰撳墠鍦烘櫙
            SceneManager.LoadScene(sceneName);
        }
    }
}
