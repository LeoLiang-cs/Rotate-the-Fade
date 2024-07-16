using UnityEngine;

public class LockDestroy : MonoBehaviour
{
    public GameObject twinHealthObject; // �Ϸ� TwinHealth ���ڵ� GameObject

    private TwinHealth twinHealthScript;

    void Start()
    {
        // ��ȡ TwinHealth ���
        twinHealthScript = twinHealthObject.GetComponent<TwinHealth>();
    }

    void Update()
    {
        if (twinHealthScript != null)
        {
            if (twinHealthScript.isDead)
            {
                Debug.Log("Twin is dead");
                GameObject sand_clock = Resources.Load<GameObject>("Prefabs/MagicProtos/sandClock");
                GameObject sand_clock_obj = GameObject.Instantiate(sand_clock) as GameObject;
                GameObject door = GameObject.Find("door1");
                sand_clock_obj.transform.position = door.transform.position + door.transform.right * 2;
                sand_clock_obj.transform.parent = door.transform;
                // �����������ִ�������߼�
                Destroy(gameObject);
            }
        }
        else
        {
            //Debug.LogError("TwinHealth script not found on the specified GameObject.");
        }
    }
}

