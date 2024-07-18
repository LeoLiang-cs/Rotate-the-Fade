using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class unlock : MonoBehaviour
{
    public CinemachineVirtualCamera follow;
    public CinemachineVirtualCamera lockCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockCam(){
        follow.Priority = 20;
        lockCam.Priority = 10;
    }
}
