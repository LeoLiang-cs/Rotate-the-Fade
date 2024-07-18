using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public Transform targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞对象是否是玩家
        if (other.CompareTag("Revive"))
        {
            // 传送玩家到目标位置
            transform.position = targetLocation.position;

        }
    }
}
