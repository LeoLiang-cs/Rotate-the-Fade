using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public GameObject lightObj;

    private SpriteRenderer spriteRenderer;
    private bool isStateOne = true;
    private bool isDone = false;



    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = image1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !isStateOne && !isDone)
        {
            //Save
            isDone = true;
            spriteRenderer.sprite = image2;
            
        }
        lightObj.SetActive(isDone);
    }

    void SwitchState()
    {
 
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
