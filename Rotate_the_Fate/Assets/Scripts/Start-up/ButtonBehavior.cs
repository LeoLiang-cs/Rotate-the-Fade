using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonStateSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // 正常状态的图片
    public Sprite hoverSprite;  // 悬停状态的图片

    private Image buttonImage;
    private bool isHovering = false;
    public static int trans = 0;

    // 引用Button组件
    private Button button;

    // 引用Button的文本组件
    private Text buttonText;

    void Start()
    {
        // 获取按钮的Image组件
        buttonImage = GetComponent<Image>();

        // 设置初始图片
        buttonImage.sprite = normalSprite;

        // 获取Button组件
        button = GetComponent<Button>();

        // 获取Button对象中的Text组件
        buttonText = button.GetComponentInChildren<Text>();

        // 修改Button的显示文本
        SetButtonText(" ");

        // 添加按钮点击事件监听器
        button.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        // 取消Update中的场景切换逻辑
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 当鼠标悬停时，切换到悬停状态图片
        buttonImage.sprite = hoverSprite;
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 当鼠标移开时，切换回正常状态图片
        buttonImage.sprite = normalSprite;
        isHovering = false;
    }

    public void SetButtonText(string newText)
    {
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
    }

    private void OnButtonClick()
    {
        // 按钮点击时切换场景
        trans = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
