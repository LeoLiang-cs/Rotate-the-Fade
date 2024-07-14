using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMagic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyVase()
    {
        Debug.Log("Destroy Vase");
        Destroy(gameObject);
    }
}
