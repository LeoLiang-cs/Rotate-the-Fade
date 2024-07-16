using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite image1;
    public Sprite image2;

    private SpriteRenderer spriteRenderer;
    public KeyCode destroyKey = KeyCode.U; // 设置要按下的键
    public float kVeryClose = 10f;
    private bool isStateOne = true;

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
        if (Input.GetKeyDown(destroyKey) && !isStateOne)
        {
            DestroyParentAndSelf();
        }
    }

    void DestroyParentAndSelf()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(gameObject);
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
