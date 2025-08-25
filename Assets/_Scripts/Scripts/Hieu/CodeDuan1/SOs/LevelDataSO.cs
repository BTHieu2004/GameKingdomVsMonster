using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData",menuName = "SO_Level/LevelData")]
public class LevelDataSO : ScriptableObject
{
    public string nameLevel;
    public LevelSO currentLevelSO;
    public List<LevelSO> listLevelSO;
}
