using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PychicsCheck : MonoBehaviour
{
    public Vector2 leftOffset;   
    public Vector2 rightOffset;  
    public Vector2 LeftgroundOffset;
    public Vector2 RightgroundOffset;


    public Vector2 LeftCheckPoint;
    public Vector2 RightCheckPoint;
    public Vector2 LeftGroundCheckPoint;
    public Vector2 RightGroundCheckPoint;

    public LayerMask groundLayer;   
    public float checkRadius;

    public bool onLeftWall;
    public bool onRightWall;
    public bool onLeftGround;
    public bool onRightGround;


    private void Update()
    {
        LeftCheckPoint=(Vector2)transform.position+leftOffset;
        Debug.Log("PythTrans"+transform.position);
        RightCheckPoint=(Vector2)transform.position+rightOffset;
        LeftGroundCheckPoint=(Vector2)transform.position+LeftgroundOffset;
        RightGroundCheckPoint=(Vector2)transform.position +RightgroundOffset;
        Check();
        //OnDrawGizmosSelected();
    }

    private void Check()
    {
        onLeftWall = Physics2D.OverlapCircle(LeftCheckPoint, checkRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle(RightCheckPoint, checkRadius, groundLayer);
        onLeftGround = Physics2D.OverlapCircle(LeftGroundCheckPoint, checkRadius, groundLayer);
        onRightGround=Physics2D.OverlapCircle(RightGroundCheckPoint,checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LeftgroundOffset,checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position+RightgroundOffset,checkRadius);
    }
}
