using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSwitch : MonoBehaviour
{
    public CameraIndex lockViewCamera;
    public GameObject leftLock;
    public GameObject rightLock;
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
            CameraManager.Instance.SwitchToCamera((int)lockViewCamera);
            leftLock.SetActive(true);
            rightLock.SetActive(false);
            // WorldRotation script = GameObject.Find("World").GetComponent<WorldRotation>();
            // script.SetMagnified(true);
        }
    }
}
