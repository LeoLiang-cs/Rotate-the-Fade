using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
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
        
        DestroyParentAndSelf();
    }

    void DestroyParentAndSelf()
    {
        Debug.Log("Destroy Vase");
        if (transform.parent != null)
        {
            Debug.Log("Destroy Wall");
            Destroy(transform.parent.gameObject);
        }
        Destroy(gameObject);
    }
}
