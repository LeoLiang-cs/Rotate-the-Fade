using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateSwitcher : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;

    private SpriteRenderer spriteRenderer;
    private bool isStateOne = true;
    public string nextSceneName;

    public float kVeryClose = 10f;
    private float GetDistanceToBlackHoleCenter(Collider2D collider)
    {
        return Vector2.Distance(transform.position, collider.transform.position);
    }

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = image1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isStateOne && ! FindObjectOfType<Attack>().isAttacking)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void SwitchState()
    {
        if (isStateOne)
        {
            spriteRenderer.sprite = image2;
        }
        else
        {
            spriteRenderer.sprite = image1;
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
        if (g.tag == "Player")
        {
            SwitchState();

        }

    }
}

