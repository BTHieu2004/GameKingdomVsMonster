using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level",menuName = "SO/Level")]
public class LevelSO : ScriptableObject
{
    public int idLevel;
    public string nameLevel;
    public int countEnemySpawn;    
    public int countSunStart;
    public int bonus;
    public bool complete;
    public bool unlock;
    public SunSO sun;
    public SoundSO soundBackGround;
    public List<EnemySO> typeEnemyInLevel;
}

