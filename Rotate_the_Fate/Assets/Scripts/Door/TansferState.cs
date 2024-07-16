using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TansferState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public SDHealth SDHealth; // 拖入TwinHealth对象到Inspector
    public GameObject door; // 拖入door对象到Inspector
    

    void Update()
    {
        if (SDHealth.isDead)
        {
            door.SetActive(true); // 显示door
            
        }
        else
        {
            door.SetActive(false); // 隐藏door
        }

    }



}
