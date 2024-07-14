using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AbilityStats{
    private AbilityStats(){}
    public static AbilityStats instance = new AbilityStats();

    public List<Sprite> ability_sprites = new List<Sprite>();
    public List<MagicType> gianed_magics = new List<MagicType>();
    public int index = -1;
    public int max_abilities = 0;
    public int chooseMagic = 0;

    public int chooseMagic = 0;

    // public static void Store_Abilities(List<Sprite> sprites, List<MagicType> magics){
    //     instance.ability_sprites = sprites;
    //     instance.gianed_magics = magics;
    // }
    public static void Set_index(int  x){
        instance.index = x;
    }
    public static void Set_Max(){
        instance.max_abilities += 1;
    }
}