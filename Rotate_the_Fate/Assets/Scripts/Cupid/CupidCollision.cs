using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidCollision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]
    public bool onGround;

    [Header("Collision")]
    public float collisionRadius = 1f;
    public Vector2 bottomOffset;
    public GameObject winUI;
    private void Awake() {
      winUI = GameObject.Find("Win");
      if(winUI != null){
        winUI.SetActive(false);
      }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
    }

      void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset};

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.name == "door1"){
        winUI.SetActive(true);
      }
    }
}
