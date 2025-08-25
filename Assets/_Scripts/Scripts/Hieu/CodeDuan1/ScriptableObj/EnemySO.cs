using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy",menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public int id;
    public string nameEnemy;
    public int damage;
    public int hpEnemy;
    public int speedEnemy;
    public GameObject objEnemy;
    public List<EffectEnemySO> effects;
    public List<SoundSO> sounds;
    public EffectEnemySO GetEffectByName(EnumEffect enumEffect)
    {
        foreach (EffectEnemySO chil in this.effects)
        {
            if (chil.enumEffect != enumEffect) continue;            
            return chil;
        }
        return null;
    }
    public SoundSO GetSoundSO(SoundName name)
    {
        foreach(SoundSO child in this.sounds)
        {
            if (child.soundName != name) continue;
            return child;
        }
        return null;
    }
}
