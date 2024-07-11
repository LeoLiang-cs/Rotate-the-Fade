using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class trigger : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Emeny OnTriggerEnter");

        TriggerCheck(collision.gameObject);

    }

    private void TriggerCheck(GameObject g)
    {
        if (g.tag == "Hero")
        {
            Camera.main.transform.position = new Vector3(target.position.x, target.position.y + 7, -10f);
        }

    }
}
