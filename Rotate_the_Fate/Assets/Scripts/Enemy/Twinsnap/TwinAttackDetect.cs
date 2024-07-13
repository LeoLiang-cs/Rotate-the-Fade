using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinAttackDetect : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask stabLayer;
    public LayerMask playerLayer;

    [Space]
    public bool onStab;
    public bool detectCupid;

    [Header("Collision")]
    public float collisionRadius = 0.2f;
    public Vector2 bottomOffset, rightOffset, leftOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onStab = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, stabLayer);

        bool onRight = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, playerLayer);
        bool onLeft = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, playerLayer);

        detectCupid = onRight || onLeft;

    }

      void OnDrawGizmos()
    {
         Gizmos.color = Color.white;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
       
    }
}
