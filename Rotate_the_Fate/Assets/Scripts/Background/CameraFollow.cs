using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform Background0, Background1, Background2, Background3, Background4, Background5;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x <= 19.8f)
        {

            transform.position = new Vector3(target.position.x, target.position.y + 3, transform.position.z);


            lastPos = transform.position;
        }




    }


}
