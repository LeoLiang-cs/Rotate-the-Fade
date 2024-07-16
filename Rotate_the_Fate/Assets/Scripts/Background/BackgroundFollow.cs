using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    public Transform Background0,Background1, Background2, Background3, Background4, Background5;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (transform.position.x <= 19.8f )
        {

            transform.position = new Vector3(target.position.x, target.position.y + 4, transform.position.z);

            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            Background0.position += new Vector3(amountToMove.x, 0f, 0f);
            Background1.position += new Vector3(amountToMove.x * 0.8f, 0f, 0f);
            Background2.position += new Vector3(amountToMove.x * 0.6f, 0f, 0f);
            Background3.position += new Vector3(amountToMove.x * 0.5f, 0f, 0f);
            Background4.position += new Vector3(amountToMove.x * 0.4f, 0f, 0f);
            Background5.position += new Vector3(amountToMove.x * 0.2f, 0f, 0f);

            lastPos = transform.position;
        }

        


    }

    
}
