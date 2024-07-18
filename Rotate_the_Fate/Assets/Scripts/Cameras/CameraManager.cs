using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public CinemachineVirtualCamera[] virtualCameras;
    private int currentCameraIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchToCamera(currentCameraIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToCamera(int cameraIndex)
    {
        if (cameraIndex < 0 || cameraIndex >= virtualCameras.Length)
        {
            Debug.LogError("Invalid camera index!");
            return;
        }

        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if(virtualCameras[i] == null){
                continue;
            }
            virtualCameras[i].Priority = (i == cameraIndex) ? 20 : 10;
        }

        currentCameraIndex = cameraIndex;
    }


}
