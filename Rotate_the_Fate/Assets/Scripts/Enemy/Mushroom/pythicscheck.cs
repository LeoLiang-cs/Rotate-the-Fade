using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pythicscheck : MonoBehaviour
{
    public Vector2 leftoffis;   //×óÆ«ÒÆ
    public Vector2 rightoffis;  //ÓÒÆ«ÒÆ
    public Vector2 groudoffis;  //µØÃæÆ«ÒÆ

    public LayerMask groudlayer;    //»·¾³Í¼²ã
    public float checkragis;

    public bool islefthall; 
    public bool isrighthall;
    public bool isOngroud;


    private void Update()
    {
        Debug.Log("checkthegroud");
        checke();
    }

    private void checke()
    {
        islefthall = Physics2D.OverlapCircle((Vector2)transform.position + leftoffis, checkragis, groudlayer);
        isrighthall = Physics2D.OverlapCircle((Vector2)transform.position + rightoffis, checkragis, groudlayer);
        isOngroud = Physics2D.OverlapCircle((Vector2)transform.position + groudoffis, checkragis, groudlayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + leftoffis, checkragis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightoffis, checkragis);
        Gizmos.DrawWireSphere((Vector2)transform.position + groudoffis, checkragis);
    }
}
