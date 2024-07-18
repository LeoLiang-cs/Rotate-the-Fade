using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.forward;
        float distance = speed * Time.deltaTime;

        if (!Physics.Raycast(transform.position, direction, distance))
        {
            rb.MovePosition(transform.position + direction * distance);
        }
    }
}
