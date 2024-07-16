using UnityEngine;

public class FloatingPlatform : MonoBehaviour, IStoppable
{
    public float speed = 2f; // ƽ���ٶ�
    public float distance = 5f; // ƽ�ƾ���

    private Vector3 startPos;
    private bool movingRight = true;

    private void OnEnable() {
        TimeManager.Instance.AddStoppable(this);
    }
    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // ƽ��ƽ̨
        if (movingRight)
        {
            transform.localPosition += Vector3.right * speed * Time.deltaTime;
            if (transform.localPosition.x >= startPos.x + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.localPosition += Vector3.left * speed * Time.deltaTime;
            if (transform.localPosition.x <= startPos.x - distance)
            {
                movingRight = true;
            }
        }
    }

    private void OnDisable() {
        TimeManager.Instance.RemoveStoppable(this);
    }

    public void Stop(){
        speed = 0f;
    }
    public void BackTo(){
        speed = 2f;
    }
}

