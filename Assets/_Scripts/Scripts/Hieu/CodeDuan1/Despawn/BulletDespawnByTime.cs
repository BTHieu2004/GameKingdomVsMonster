using Unity.Properties;
using UnityEngine;

public class BulletDespawnByTime : Despawn<Bullet>
{
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.isDespawnByTime = true;
    }
}
