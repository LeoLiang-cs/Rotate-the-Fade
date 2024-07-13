using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pythicscheck : MonoBehaviour
{
    public Vector2 leftoffis;   //��ƫ��
    public Vector2 rightoffis;  //��ƫ��
    public Vector2 groudoffis;  //����ƫ��

    public LayerMask groudlayer;    //����ͼ��
    public float checkragis;

    public bool islefthall; 
    public bool isrighthall;
    public bool isOngroud;
    public Enemy Mushroom;


    private void Update()
    {
        //Debug.Log("checkthegroud");
        check();
        Mushroom = GetComponent<Enemy>();
    }

    private void check()
    {
        islefthall = Physics2D.OverlapCircle((Vector2)transform.position + leftoffis, checkragis, groudlayer);
        isrighthall = Physics2D.OverlapCircle((Vector2)transform.position + rightoffis, checkragis, groudlayer);
        isOngroud = Physics2D.OverlapCircle((Vector2)transform.position + groudoffis*-Mushroom.faceDire, checkragis, groudlayer);
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere((Vector2)transform.position + leftoffis, checkragis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightoffis, checkragis);
        Gizmos.DrawWireSphere((Vector2)transform.position + groudoffis, checkragis);
    }
}
