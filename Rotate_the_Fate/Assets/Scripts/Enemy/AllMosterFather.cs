using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMosterFather : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currspeed;
    public float normalspeed;
    public float chasespeed;
    public Vector3 faceDire;
    public float slowcl;//МѕТ§вђзг
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move()
    {
        rb.velocity = new Vector2(faceDire.x * currspeed * Time.deltaTime * slowcl, rb.velocity.y);
    }
}
