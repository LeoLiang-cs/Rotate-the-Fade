using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BirdButton : MonoBehaviour
{
    public UnityEvent onClick;

    public Sprite normalSprite; // 正常状态的图片
    public Sprite hoverSprite;  // 悬停状态的图片
    public string nextSceneName;
    private SpriteRenderer buttonSprite;


    private bool isHovering = false;


    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 取消Update中的场景切换逻辑
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnMouseEnter()
    {
        buttonSprite.sprite = hoverSprite;
        isHovering = true;
        Debug.Log("Mouse entered " + gameObject.name);
    }

    private void OnMouseExit()
    {
        buttonSprite.sprite = normalSprite;
        isHovering = false;
        Debug.Log("Mouse exited " + gameObject.name);
    }


}
