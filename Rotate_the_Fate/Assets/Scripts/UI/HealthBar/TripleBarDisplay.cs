using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TripleBarDisplay : MonoBehaviour
{
    private float value;
    private float lerp_timer;
    private const float MAX_VALUE = 10f;
    private const float CHASE_TIME = 2f;
    private float magic_cost = 0f;
    public Image front_value_bar;
    public Image middle_value_bar;
    public Image back_value_bar;
    private float twinkle_period = 0.5f;
    private float twinkle_elapse = 0f;
    private bool twinkle_mode = true;

    private const float color_ratio = 0.6f;
    private float last_value;
    private List<Sprite> bar_colors;
    private void Awake() {
        bar_colors = new List<Sprite>();
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.VALUE_BAR_FRAME_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.BACKGROUND_HEALTH_BAR_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.BLANK_VALUE_BAR_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.SLIME_HEALTH_BAR_PATH));
        bar_colors.Add(Resources.Load<Sprite>(ResourcesPath.SLIME_ENERGY_BAR_PATH));
    }
    // Start is called before the first frame update
    void Start()
    {
        value = MAX_VALUE;
        last_value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp(value, 0f, MAX_VALUE);
        // if(Input.GetKeyDown(KeyCode.X)){
        //     TakeDamage(Random.Range(5,20));
        //     Debug.Log("input x");
        // }
        // if(Input.GetKeyDown(KeyCode.C)){
        //     GetHealed(Random.Range(5,20));
        // }
        UpdateValue();
        twinkle_elapse += Time.deltaTime;
        if(twinkle_elapse >= twinkle_period){
            twinkle_mode = !twinkle_mode;
            twinkle_elapse = 0f;
        }
        if(twinkle_mode){
            middle_value_bar.sprite = bar_colors[(int)ValueBarEnum.EnergySlime];
            middle_value_bar.color = Color.white;
        }else{
            middle_value_bar.color = new Color(0.65f, 0.65f, 0.65f, 0.84f); // gray
            middle_value_bar.sprite = bar_colors[(int)ValueBarEnum.ValueBlank];
        }
    }

    public void UpdateValue(){
        float fill_front = front_value_bar.fillAmount;
        float fill_middle = middle_value_bar.fillAmount;
        float fill_back = back_value_bar.fillAmount;
        float current_fraction = value / MAX_VALUE;
        float cost_fraction = magic_cost / MAX_VALUE;
        if(fill_back > current_fraction || (fill_middle < current_fraction && current_fraction > last_value)){ 
            // value decrease or recovery less than decrease
            back_value_bar.color = new Color(color_ratio, 0f, 0f);
            // fill_middle = fill_front;
            // middle_value_bar.fillAmount = fill_front;
            middle_value_bar.fillAmount = current_fraction;
            float front_fraction = Mathf.Clamp01(current_fraction - cost_fraction); // restrict the range to [0, 1]
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            front_value_bar.fillAmount = Mathf.Lerp(fill_front, front_fraction, update_percentage);
            back_value_bar.fillAmount = Mathf.Lerp(fill_back, fill_middle, update_percentage * 0.5f);
        }
        if(fill_back <= current_fraction || (last_value > current_fraction && fill_middle < current_fraction)){
            // value recover or decrease less than recovery 
            back_value_bar.color = new Color(0f, color_ratio, 0f);
            back_value_bar.fillAmount = current_fraction;
            lerp_timer += Time.deltaTime;
            float update_percentage = lerp_timer / CHASE_TIME;
            middle_value_bar.fillAmount = Mathf.Lerp(fill_middle, current_fraction, update_percentage);
            float front_fraction = Mathf.Clamp01(current_fraction - cost_fraction);
            front_value_bar.fillAmount = Mathf.Lerp(fill_front, front_fraction, update_percentage * 0.5f);
        }
        last_value = current_fraction;
    }

    public void ValueDecrease(float damage){
        value -= damage;
        lerp_timer = 0f;
    }

    public void ValueIncrease(float recovery){
        value += recovery;
        lerp_timer = 0f;
    }

    public void Set_Cost(float cost){
        magic_cost = cost;
    }
}
