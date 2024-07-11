using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.U2D;

public class TimeEffect : MonoBehaviour
{
    private const float freeze_period = 3f;
    private float effect_speed = 200f;
    private const float MAX_SIZE = 150f; // denpend on size of the camera
    private const float MIN_SIZE = 0.1f; // need to be test with min size of the slime
    // private const float soundEffectOffset = 0.5f;
    private GameObject parent;
    private Timer timer;
    private bool dilate = true;
    private bool shrink = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(MIN_SIZE, MIN_SIZE, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(parent){
            transform.position = parent.transform.position;

            if(transform.localScale.x < MAX_SIZE && dilate){
                transform.localScale += new Vector3(effect_speed, effect_speed, 0f) * Time.smoothDeltaTime;
            }
            else if(dilate){
                dilate = false;
                StartCoroutine(Resume());
            }
            else if(shrink){
                if(transform.localScale.x > MIN_SIZE){
                    transform.localScale -= new Vector3(effect_speed, effect_speed, 0f) * Time.smoothDeltaTime;
                }else{
                    Destroy(gameObject);
                }
            }
        }
        
        
        // if(effect_elapse >= 3f){
        //     TimeMagic.magic_start = false;
        //     if(transform.localScale.x > 0.1f){
        //         if(!end_sfx){
        //             AudioManager.Instance.PlaySFX(SFXClips.time_freeze_end);
        //             end_sfx = true;
        //     }
        //         Debug.Log("shrinking");
        //         Vector3 shrink = new Vector3(effect_speed, effect_speed, 0f) * Time.smoothDeltaTime;
        //         Debug.Log(shrink);
        //         transform.localScale -= shrink;
        //     }else{
        //         // while(soundStart)
        //         // soundStart = true;
        //         Debug.Log("finish");
        //         MagicCtrlor.TimeStop = false;
        //         start_sfx = false;
        //         effect_elapse = 0f;
        //         Destroy(gameObject);
        //     }
        // }
    }
    public void Set_up(Timer freeze_timer, GameObject gameObject){
        TimeManager.Instance.PauseTime(freeze_timer);
        timer = freeze_timer;
        parent = gameObject;
    }

    IEnumerator Resume()
    {
        const float shrink_time = 0.5f;
        yield return new WaitForSeconds(freeze_period - shrink_time);

        shrink = true;
        yield return new WaitForSeconds(shrink_time);
        TimeManager.Instance.ResumeTime();
    }
}
