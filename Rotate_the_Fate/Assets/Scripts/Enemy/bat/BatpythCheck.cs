using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatpythCheck : MonoBehaviour
{

    public Vector2 leftOffset;   //��ƫ��
    public Vector2 rightOffset;  //��ƫ��
    public Vector2 groundOffset;  //����ƫ��
    public Vector2 TopOffset;

    public LayerMask groundLayer;    //����ͼ��
    public float checkRadius;

    public bool onLeftWall;
    public bool onRightWall;
    public bool onGround;
    public bool onTop;
    public Enemy Mushroom;


    private void Update()
    {
        check();
        Mushroom = GetComponent<Enemy>();
    }

    public void check()
    {
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.localPosition + leftOffset, checkRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.localPosition + rightOffset, checkRadius, groundLayer);
        onGround = Physics2D.OverlapCircle((Vector2)transform.localPosition + groundOffset , checkRadius, groundLayer);
        onTop = Physics2D.OverlapCircle((Vector2)transform.localPosition + TopOffset, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere((Vector2)transform.localPosition + leftOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.localPosition + rightOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.localPosition + groundOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.localPosition + TopOffset, checkRadius);
    }
}

