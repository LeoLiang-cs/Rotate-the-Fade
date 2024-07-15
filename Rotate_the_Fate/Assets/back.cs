using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneReset();
    }

     void SceneReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            // 重新加载当前场景
            SceneManager.LoadScene(sceneName);
        }
    }
}
