using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EffectEnemy",fileName = "EffectEnemy")]
public class EffectEnemySO : ScriptableObject
{
    public int id;
    public string nameEffect;
    public EnumEffect enumEffect;
    public GameObject effect;
    public List<SoundSO> sounds;
}
