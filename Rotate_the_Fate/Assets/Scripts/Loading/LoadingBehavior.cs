using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBehavior : MonoBehaviour
{
    public float rotationSpeed = 50f;
    private void Rotation()      //Ê¹ºÚ¶´×Ô×ª
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * (-1));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
