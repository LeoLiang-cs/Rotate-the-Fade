using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            FindObjectOfType<AudioManager>().Play("Test");
        }
        if(Input.GetKeyDown(KeyCode.K)){
            FindObjectOfType<AudioManager>().Play("Test2");
        }
    }
}
