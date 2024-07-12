using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    public Transform farBackground, midBackground;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x <= 19.8f )
        {

            transform.position = new Vector3(target.position.x, target.position.y + 7, transform.position.z);

            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
            midBackground.position = new Vector3(amountToMove.x * 0.5f, amountToMove.y * 0.5f, 0f);

            lastPos = transform.position;
        }

        


    }

    
}
