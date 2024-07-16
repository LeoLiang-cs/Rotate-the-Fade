using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDDetect : MonoBehaviour
{
    private SDHealth sdHealth;
    [Header("Layers")]
    public LayerMask playerLayer;
    public bool detectCupid;

    [Header("Collision")]
    public Vector2 boxSize = new Vector2(1f, 1f); // 方形碰撞检测的大小
    public Vector2 offset;

    void Awake()
    {
        sdHealth = GetComponent<SDHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sdHealth.isDemon)
        {
            detectCupid = Physics2D.OverlapBox((Vector2)transform.position + offset, boxSize, 0f, playerLayer);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        // 绘制方形检测区域
        Gizmos.DrawWireCube((Vector2)transform.position + offset, boxSize);

    }
}
