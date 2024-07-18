using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CollectableSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera lockViewCamera;
    public BoxCollider2D leftLock;
    public BoxCollider2D rightLock;
    private void Awake() {
        Debug.Assert(leftLock != null && rightLock != null);
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            lockViewCamera.Priority = 20;
            leftLock.isTrigger = false;
            rightLock.isTrigger = false;
            // WorldRotation script = GameObject.Find("World").GetComponent<WorldRotation>();
            // script.SetMagnified(true);
        }
    }
}
