using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public float timeToDestroy = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
