using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdBehavior : MonoBehaviour
{
    public float speed = -2f;

    public GameObject backgroundObject; // 包含 BackgroundFollow 脚本的游戏对象
    //public Transform newTarget; // 新的目标

    private BackgroundFollow backgroundFollowScript;
    


    void Update()
    {

        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -100f)
        {
            transform.position = new Vector3(-40f, transform.position.y, transform.position.z);
        }
        //if (Input.GetKeyDown(KeyCode.Space) )
        //{
        //    backgroundFollowScript = backgroundObject.GetComponent<BackgroundFollow>();
        //    backgroundFollowScript.target = newTarget;
        //}
    }



}



