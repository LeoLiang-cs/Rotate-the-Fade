using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 leftOffset;   //��ƫ��
    public Vector2 rightOffset;  //��ƫ��
    public Vector2 groundOffset;  //����ƫ��

    public LayerMask groundLayer;    //����ͼ��
    public float checkRadius;

    public bool onLeftWall; 
    public bool onRightWall;
    public bool onGround;
    public Enemy Mushroom;


    private void Update()
    {
        check();
        Mushroom = GetComponent<Enemy>();
    }

    private void check()
    {
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRadius, groundLayer);
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset*-Mushroom.faceDire, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + groundOffset, checkRadius);
    }
}
