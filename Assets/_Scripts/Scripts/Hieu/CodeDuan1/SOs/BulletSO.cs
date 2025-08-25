using UnityEngine;

[CreateAssetMenu(fileName = "Bullet",menuName = "SO/Bullet")]
public class BulletSO : ScriptableObject
{
    public string nameBullet;
    public int damage;
    public float speed;
    public GameObject objBullet;
    public EffectBulletSO effectBulletSO;
}
