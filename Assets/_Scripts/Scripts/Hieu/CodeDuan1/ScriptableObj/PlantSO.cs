using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Plant",fileName = "Plant")]
public class PlantSO : ScriptableObject
{
    public string id;
    public string namePlan;
    public PlantType typePlant;
    public string description;
    public Sprite sprite;
    public int Price;
    public int hpPlant;
    public int damage;
    public float rangeAttack;        
    public float cooldownTimeTower;
    public bool unLock;
    public bool selected;
    public GameObject objPlant;
    public BulletSO bullet;
    public List<SoundSO> sounds;
    public SoundSO GetSoundSO(SoundName soundName)
    {
        foreach (SoundSO child in sounds)
        {
            if (child.soundName != soundName) continue;
            return child;
        }
        return null;
    }
}
