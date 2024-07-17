using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveState : MonoBehaviour
{
    private bool isStateOne = true; // 初始状态
    public string nextSceneName; // 下一个场景的名称

    public float kVeryClose = 10f;
    private float GetDistanceToBlackHoleCenter(Collider2D collider)
    {
        return Vector2.Distance(transform.position, collider.transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isStateOne && !Attack.isAttacking)
        {
            SceneManager.LoadScene(nextSceneName);  // 加载下一个场景
        }
    }

    void SwitchState()
    {

        isStateOne = !isStateOne;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Emeny OnTriggerEnter");

        TriggerCheck(collision.gameObject);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Emeny OnTriggerEnter");

        TriggerCheck(collision.gameObject);

    }



    private void TriggerCheck(GameObject g)
    {
        if (g.tag == "Player")
        {
            SwitchState();

        }

    }
}
