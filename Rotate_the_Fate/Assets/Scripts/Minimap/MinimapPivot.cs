using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPivot : MonoBehaviour
{
    public GameObject pivot;
    private void Awake() {
        pivot = GameObject.Find("MinimapPivot");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pivot.transform.position;
    }
}
