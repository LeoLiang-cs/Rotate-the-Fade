using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthDisplay : MonoBehaviour
{
    private float health;
    private float lerp_timer;
    private const float MAX_HEALTH = 10f;
    private const float CHASE_TIME = 2f;
    public Image front_health_bar;
    public Image back_health_bar;
    private float last_health;
    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        last_health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0f, MAX_HEALTH);
        // if(Input.GetKeyDown(KeyCode.X)){
        //     TakeDamage(Random.Range(5,20));
        //     // Debug.Log("input x");
        // }
        // if(Input.GetKeyDown(KeyCode.C)){
        //     GetHealed(Random.Range(5,20));
        // }
        UpdateHealth();
    }

    public void UpdateHealth(){
        float fill_front = front_health_bar.fillAmount;
        float fill_back = back_health_bar.fillAmount;
        float current_fraction = health / MAX_HEALTH;

        if(fill_back > current_fraction || (fill_front < current_fraction && current_fraction > last_health)){ 
            // health decrease or recovery less than decrease
            back_health_bar.color = ColorUtil.BossDecrease;
            // fill_middle = fill_front;
            // middle_health_bar.fillAmount = fill_front;
            front_health_bar.fillAmount = current_fraction;
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            back_health_bar.fillAmount = Mathf.Lerp(fill_back, fill_front, update_percentage);
        }
        if(fill_back <= current_fraction || (last_health > current_fraction && fill_front < current_fraction)){
            // health recover or decrease less than recovery 
            back_health_bar.color = ColorUtil.BossHealing;
            back_health_bar.fillAmount = current_fraction;
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            front_health_bar.fillAmount = Mathf.Lerp(fill_front, current_fraction, update_percentage);
        }
        last_health = current_fraction;
    }

    public void TakeDamage(float damage){
        health -= damage;
        lerp_timer = 0f;
    }

    public void GetHealed(float recovery){
        health += recovery;
        lerp_timer = 0f;
    }
}
