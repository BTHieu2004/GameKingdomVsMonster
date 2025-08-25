using UnityEngine;

public class DespawnExplosionSO : Despawn<EffectMonsterCtrt>
{
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.timeLife = 1f;
    }
}
