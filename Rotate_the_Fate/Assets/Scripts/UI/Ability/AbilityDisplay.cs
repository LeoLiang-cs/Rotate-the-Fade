using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AbilityDisplay : MonoBehaviour
{
    private int index = -1;
    private List<Sprite> ability_sprites;
    private int max_abilities = 0;
    private Image ability_icon;
    private const string FROST_PATH = "Image/Abilities/Frost";
    private const string FLAME_PATH = "Image/Abilities/Flame";
    private const string LIGHTENING_PATH = "Image/Abilities/Lightening";
    private const string TIME_PATH = "Image/Abilities/TheWorld";
    private void Awake() {
        ability_sprites = new List<Sprite>();
        ability_icon = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            Add_Ability("frost");
            Switch_Ability();
            ability_icon.color = Color.white;
        }else if(Input.GetKeyDown(KeyCode.I)){
            Add_Ability("lightening");
            // Debug.Log("flame");
        }else if(Input.GetKeyDown(KeyCode.O)){
            Add_Ability("flame");
        }
        else if(Input.GetKeyDown(KeyCode.P)){
            Add_Ability("time");
        }
        if(Input.GetKeyDown(KeyCode.H)){
            Switch_Ability();
        }
    }

    public void Add_Ability(string ability_name){
        if(ability_name == "frost"){
            // Debug.Log("add frost");
            ability_sprites.Add(Resources.Load<Sprite>(FROST_PATH));
            max_abilities += 1;
        }else if(ability_name == "flame"){
            ability_sprites.Add(Resources.Load<Sprite>(FLAME_PATH));
            max_abilities += 1;
        }
        else if(ability_name == "lightening"){
            ability_sprites.Add(Resources.Load<Sprite>(LIGHTENING_PATH));
            max_abilities += 1;
        }
        else if(ability_name == "time"){
            ability_sprites.Add(Resources.Load<Sprite>(TIME_PATH));
            max_abilities += 1;
        }
    }

    public void Switch_Ability(){
        index += 1;
        index %= max_abilities;
        ability_icon.sprite = ability_sprites[index];
    }

}
