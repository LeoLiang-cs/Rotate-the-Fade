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
    public Transform cupidBehavior; // Ŀ�����?
    private Vector3 rotationCenter;
    private float targetAngle;
    private float currentAngle;
    public static bool isClockwise;
    void Awake()
    {
        isRotating = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isMagnifing = false;
    }

    // Update is called once per frame
    void Update()
    {
        SceneReset();
        if(isMagnifing)
            return;
        Rotation();
        
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
    //         targetAngle = 90f; // Ŀ����ת�Ƕ�Ϊ90��
    //         isClockwise = true;
    //     }

    //     if (Input.GetKeyDown(KeyCode.E) && !isRotating && cupidBehavior.GetComponent<Collision>().onGround)
    //     {
    //         FindObjectOfType<AudioManager>().Play("Rotate");
    //         isRotating = true;
    //         rotationCenter = cupidBehavior.transform.position;
    //         currentAngle = 0f;
    //         targetAngle = -90f; // Ŀ����ת�Ƕ�Ϊ-90�ȣ���ʱ�룩
    //         isClockwise = false;
    //     }

    //     if (isRotating)
    //     {
    //         // ÿ֡��תһ���Ƕ�
    //         float angleToRotate = rotationSpeed * Time.deltaTime;
    //         if (!isClockwise)
    //             angleToRotate = -angleToRotate;

    //         currentAngle += angleToRotate;

    //         if (Mathf.Abs(currentAngle) >= Mathf.Abs(targetAngle))
    //         {
    //             angleToRotate = targetAngle - (currentAngle - angleToRotate);
    //             isRotating = false; // �ﵽĿ��ǶȺ�ֹͣ���?
    //         }

    //         // ��rotationCenterΪ������ת
    //         transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate);

    //     }
    // }

        void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating && cupidBehavior.GetComponent<Collision>().onGround)
        {
            FindObjectOfType<AudioManager>().Play("Rotate");
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = 90f; // Ŀ����ת�Ƕ�Ϊ90��
            isClockwise = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating && cupidBehavior.GetComponent<Collision>().onGround)
        {
            FindObjectOfType<AudioManager>().Play("Rotate");
            isRotating = true;
            rotationCenter = cupidBehavior.transform.position;
            currentAngle = 0f;
            targetAngle = -90f; // Ŀ����ת�Ƕ�Ϊ-90�ȣ���ʱ�룩
            isClockwise = false;
        }

        if (isRotating)
        {
            // ÿ֡��תһ���Ƕ�
            float angleToRotate = rotationSpeed * Time.deltaTime;
            if (!isClockwise)
                angleToRotate = -angleToRotate;

            currentAngle += angleToRotate;

            if (Mathf.Abs(currentAngle) >= Mathf.Abs(targetAngle))
            {
                angleToRotate = targetAngle - (currentAngle - angleToRotate);
                isRotating = false; // �ﵽĿ��ǶȺ�ֹͣ���?
            }

            // ��rotationCenterΪ������ת
            transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate);

        }
    }



    void SceneReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            // 重新加载当前场景
            SceneManager.LoadScene(sceneName);
        }
    }

    public void SetMagnified(bool magnify)
    {
        isMagnifing = magnify;
    }

}
