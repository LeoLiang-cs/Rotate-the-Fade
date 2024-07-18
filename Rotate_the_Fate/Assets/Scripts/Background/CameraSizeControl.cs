using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CameraSizeController : MonoBehaviour
{
    public string targetSceneName; // 目标场景名称
    public float targetOrthoSize; // 目标正交尺寸

    private CinemachineVirtualCamera vCam;

    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        if (vCam == null)
        {
            Debug.LogError("CinemachineVirtualCamera component not found on this GameObject.");
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateCameraSize(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateCameraSize(scene.name);
    }

    void UpdateCameraSize(string sceneName)
    {
        if (sceneName == targetSceneName)
        {
            vCam.m_Lens.OrthographicSize = targetOrthoSize;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

