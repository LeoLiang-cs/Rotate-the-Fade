using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster {
    private static EnemyMaster instance; 
    private List<EnemyManger> enemies;

    private EnemyMaster(){
        enemies = new List<EnemyManger>();
    }
    public static EnemyMaster Instance{
        get
        {
            if (instance == null)
            {
                instance = new EnemyMaster();
            }
            return instance;
        }
    }

    public void AddEnemy(EnemyManger enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
        }
    }

    public void RemoveEnemy(EnemyManger enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }

    public void Freeze(){
        foreach (EnemyManger enemy in enemies)
        {
            enemy.Stop();
        }
    }

    public void Resume(){
        foreach (EnemyManger enemy in enemies)
        {
            enemy.BackTo();
        }
    }
}