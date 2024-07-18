using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBndSwitch : MonoBehaviour
{
    public CameraIndex lockViewCamera;
    private BoxCollider2D boxCollider2D;
    public BoxCollider2D otherCollider;
    private void Awake() {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player" && other.transform.position.x > transform.position.x){
            CameraManager.Instance.SwitchToCamera((int)lockViewCamera);
            boxCollider2D.isTrigger = false;
            otherCollider.isTrigger = false;
        }
    }
}
