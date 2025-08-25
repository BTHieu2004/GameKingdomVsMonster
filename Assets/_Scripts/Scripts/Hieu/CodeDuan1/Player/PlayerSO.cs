using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player",menuName = "SO/Player")]
public class PlayerSO : ScriptableObject
{
    public int id;
    public string namePlayer;
    public int money;
    public List<PlantSO> plants;
}
