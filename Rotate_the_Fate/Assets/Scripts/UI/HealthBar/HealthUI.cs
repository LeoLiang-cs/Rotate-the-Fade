using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private float health;
    private float lerp_timer;
    private const float MAX_HEALTH = 10f;
    private const float CHASE_TIME = 2f;
    private float magic_cost = 2f;
    public Image front_health_bar;
    public Image middle_health_bar;
    public Image back_health_bar;
    private float twinkle_period = 0.5f;
    private float twinkle_elapse = 0f;
    private bool twinkle_mode = true;

    private const float color_ratio = 0.6f;
    private float last_health;
    private List<Sprite> bar_colors;
    private void Awake() {
        bar_colors = new List<Sprite>();
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.HEALTH_BAR_FRAME_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.BACKGROUND_HEALTH_BAR_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.BLANK_HEALTH_BAR_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.SLIME_HEALTH_BAR_PATH));
    }
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
        if(Input.GetKeyDown(KeyCode.X)){
            TakeDamage(Random.Range(5,20));
            Debug.Log("input x");
        }
        if(Input.GetKeyDown(KeyCode.C)){
            GetHealed(Random.Range(5,20));
        }
        UpdateHealth();
        twinkle_elapse += Time.deltaTime;
        if(twinkle_elapse >= twinkle_period){
            twinkle_mode = !twinkle_mode;
            twinkle_elapse = 0f;
        }
        if(twinkle_mode){
            middle_health_bar.sprite = bar_colors[(int)HealthBarEnum.HealthSlime];
            middle_health_bar.color = Color.white;
        }else{
            middle_health_bar.color = new Color(0.65f, 0.65f, 0.65f, 0.84f); // gray
            middle_health_bar.sprite = bar_colors[(int)HealthBarEnum.HealthBlank];
        }
    }

    public void UpdateHealth(){
        float fill_front = front_health_bar.fillAmount;
        float fill_middle = middle_health_bar.fillAmount;
        float fill_back = back_health_bar.fillAmount;
        float current_fraction = health / MAX_HEALTH;
        float cost_fraction = magic_cost / MAX_HEALTH;
        if(fill_back > current_fraction || (fill_middle < current_fraction && current_fraction > last_health)){ 
            // health decrease or recovery less than decrease
            back_health_bar.color = new Color(color_ratio, 0f, 0f);
            // fill_middle = fill_front;
            // middle_health_bar.fillAmount = fill_front;
            middle_health_bar.fillAmount = current_fraction;
            float front_fraction = Mathf.Clamp01(current_fraction - cost_fraction); // restrict the range to [0, 1]
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            front_health_bar.fillAmount = Mathf.Lerp(fill_front, front_fraction, update_percentage);
            back_health_bar.fillAmount = Mathf.Lerp(fill_back, fill_middle, update_percentage * 0.5f);
        }
        if(fill_back <= current_fraction || (last_health > current_fraction && fill_middle < current_fraction)){
            // health recover or decrease less than recovery 
            back_health_bar.color = new Color(0f, color_ratio, 0f);
            back_health_bar.fillAmount = current_fraction;
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            middle_health_bar.fillAmount = Mathf.Lerp(fill_middle, current_fraction, update_percentage);
            float front_fraction = Mathf.Clamp01(current_fraction - cost_fraction);
            front_health_bar.fillAmount = Mathf.Lerp(fill_front, front_fraction, update_percentage * 0.5f);
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

    public void Set_Cost(float cost){
        magic_cost = cost;
    }
}
