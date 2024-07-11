using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextSceneName; // 下一个场景的名称
    public float delay = 3f;     // 停留时间

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay); // 等待指定的秒数
        SceneManager.LoadScene(nextSceneName);  // 加载下一个场景
    }
}
