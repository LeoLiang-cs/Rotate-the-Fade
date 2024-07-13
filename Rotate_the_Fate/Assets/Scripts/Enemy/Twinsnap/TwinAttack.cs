using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinAttack : MonoBehaviour
{
    Collision coll;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Bite();
    }

    void Bite()
    {
        if (coll.onWall)
        {
            anim.SetBool("Bite", true);
        }
    }

    void EndBite()
    {
        anim.SetBool("Bite", false);
     }
}
