using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGround : MonoBehaviour
{
    private Transform camTF;
    private Vector3 lastFrameCameraPos;
    private float texureUnitySizeX;
    private float texureUnitySizeY;

    [SerializeField] private Vector2 prallaxFactor;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockX;

    // Start is called before the first frame update
    void Start()
    {
        camTF = Camera.main.transform;
        lastFrameCameraPos = camTF.position;
        Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;
        texureUnitySizeX = sprite.texture.width / sprite.pixelsPerUnit;
        texureUnitySizeY = sprite.texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaMovement = camTF.position - lastFrameCameraPos;
        transform.position = transform.position + new Vector3(deltaMovement.x * prallaxFactor.x, deltaMovement.y * prallaxFactor.y, 0);
        lastFrameCameraPos = camTF.position;

        if (lockX)
        {
            if (Mathf.Abs( camTF.position.x - transform.position.x ) >= texureUnitySizeX)
            {
                float offsetX = camTF.position.x - transform.position.x;
                transform.position = new Vector3(camTF.position.x + offsetX, transform.position.y);
            }
        }
        if(lockY)
        {
            if (Mathf.Abs(camTF.position.y - transform.position.y) >= texureUnitySizeY)
            {
                float offsetY = camTF.position.y - transform.position.y;
                transform.position = new Vector3(camTF.position.x, transform.position.y + offsetY);
            }
        }
        
    }
}
