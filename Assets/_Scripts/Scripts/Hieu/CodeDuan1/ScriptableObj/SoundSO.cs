using UnityEngine;

[CreateAssetMenu(fileName = "Sound",menuName = "SO/Sound")]
public class SoundSO : ScriptableObject
{
    public int id;
    public SoundName soundName;
    public GameObject objSound;
}
