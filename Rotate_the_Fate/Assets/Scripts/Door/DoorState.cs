using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateSwitcher : MonoBehaviour
{
    public Sprite image1; // 第一张图片
    public Sprite image2; // 第二张图片

    private SpriteRenderer spriteRenderer;
    private bool isStateOne = true; // 初始状态

    public float kVeryClose = 10f;
    private float GetDistanceToBlackHoleCenter(Collider2D collider)
    {
        return Vector2.Distance(transform.position, collider.transform.position);
    }

    void Start()
    {
        // 获取SpriteRenderer组件
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 设置初始图片
        spriteRenderer.sprite = image1;
    }

    void Update()
    {
        // 检测输入（例如按下空格键）来切换状态
        if (Input.GetKeyDown(KeyCode.S) && !isStateOne)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void SwitchState()
    {
        if (isStateOne)
        {
            spriteRenderer.sprite = image2; // 切换到第二状态
        }
        else
        {
            spriteRenderer.sprite = image1; // 切换到第一状态
        }

        isStateOne = !isStateOne;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Emeny OnTriggerEnter");

        TriggerCheck(collision.gameObject);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Emeny OnTriggerEnter");

        TriggerCheck(collision.gameObject);

    }



    private void TriggerCheck(GameObject g)
    {
        if (g.tag == "Hero")
        {
            SwitchState();

        }

    }
}

