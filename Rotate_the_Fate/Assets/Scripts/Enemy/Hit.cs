using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int mFrozenCount = 0;
    private SpriteRenderer spriteRenderer;
    private GameObject mIceBlockSample = null;
    private float mFrozenTime = 2.0f;
    private float mFrozenTimeCount = 0.0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mIceBlockSample = Resources.Load<GameObject>("Prefabs/FrozenEffect") as GameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MeltFrozen();
    }

    public void TakeFrozenDamage(int damage, Vector2 attP) {
        if(mFrozenCount == 0) {
            if(attP.x < transform.position.x) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * 5, ForceMode2D.Impulse);
            } else {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * 5, ForceMode2D.Impulse);
            }
            spriteRenderer.color = new Color(0.078f, 0.761f, 1.0f); // RGB values for #14C2FF

            mFrozenCount++;
            mFrozenTimeCount = mFrozenTime;
        }else if(mFrozenCount == 1) {
            GameObject iceBlock = GameObject.Instantiate(mIceBlockSample) as GameObject;
            iceBlock.transform.localPosition = transform.position;
            iceBlock.transform.parent = transform;
            anim.speed = 0;
            mFrozenCount++;
            mFrozenTimeCount = mFrozenTime;
        }
    }

    public void TakeFlameDamage(int damage, Vector2 attP) {
        if(attP.x < transform.position.x) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 10, ForceMode2D.Impulse);
        } else {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * 10, ForceMode2D.Impulse);
        }
        spriteRenderer.color = Color.red; 
        anim.SetTrigger("Hit");
    }    

    public void TakeLighteningChainDamage(int damage) {
        
        spriteRenderer.color = Color.yellow; 
    }    

    private void MeltFrozen() {
        if(mFrozenCount == 2) {
            if(mFrozenTimeCount <= 0) {
                anim.speed = 1;
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
                //把iceBlock给销毁
                foreach(Transform child in transform) {
                    GameObject.Destroy(child.gameObject);
                }
            }
            mFrozenTimeCount -= Time.deltaTime;
        } else
        if(mFrozenCount == 1) {
            if(mFrozenTimeCount <= 0) {
                spriteRenderer.color = Color.white;
                mFrozenCount = 0;
            }
            mFrozenTimeCount -= Time.deltaTime;
        }
    }
    
}
