using UnityEngine;

public class LockDestroy : MonoBehaviour
{
    public GameObject twinHealthObject; // 拖放 TwinHealth 所在的 GameObject

    private TwinHealth twinHealthScript;

    void Start()
    {
        // 获取 TwinHealth 组件
        twinHealthScript = twinHealthObject.GetComponent<TwinHealth>();
    }

    void Update()
    {
        if (twinHealthScript != null)
        {
            if (twinHealthScript.isDead)
            {
                //Debug.Log("Twin is dead");
                // 你可以在这里执行其他逻辑
                Destroy(gameObject);
            }
        }
        else
        {
            //Debug.LogError("TwinHealth script not found on the specified GameObject.");
        }
    }
}

